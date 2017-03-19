using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;
using AutoMapper;
using System.Data.Entity;

namespace EADN.Semester.QuizGame.Persistence.EF.Repositories
{
    public class QuestionRepository : IQuestionRepository<Common.Question, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Question> dbSet;
        public QuestionRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Question>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Question, Question>()
                    .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
                cfg.CreateMap<Question, Common.Question>();
                cfg.CreateMap<Common.Topic, Topic>();
                cfg.CreateMap<Topic, Common.Topic>();
                cfg.CreateMap<Common.Quiz, Quiz>();
                cfg.CreateMap<Quiz, Common.Quiz>();
                cfg.CreateMap<Common.Answer, Answer>();
                cfg.CreateMap<Answer, Common.Answer>();
            });
        }
        public void Create(Common.Question data)
        {
            Question newQuestion = Mapper.Map<Question>(data);
            dbSet.Add(newQuestion);
        }
        public Common.Question Read(Guid key)
        {
            Question question = dbSet.Find(key);

            return Mapper.Map<Common.Question>(question);
        }
        public void Update(Common.Question data)
        {
            // Mapping
            Question updateQuestion = Mapper.Map<Question>(data);
            List<Topic> updateTopics = Mapper.Map<List<Topic>>(data.Topics);
            List<Quiz> updateQuizzes = Mapper.Map<List<Quiz>>(data.Quizzes);
            List<Answer> updateAnswers = Mapper.Map<List<Answer>>(data.Answers);

            // Update
            updateQuestion = dbSet.Find(data.Id);
            updateQuestion.Name = data.Name;
            updateQuestion.Text = data.Text;
            updateQuestion.Quizzes = UpdateQuizzesList(updateQuestion, updateQuizzes);
            updateQuestion.Topics = UpdateTopicList(updateQuestion, updateTopics);
            updateQuestion.Answers = UpdateAnswerList(updateQuestion, updateAnswers);

            dbSet.Attach(updateQuestion);
            context.Entry(updateQuestion).State = EntityState.Modified;
        }
        public void Delete(Guid key)
        {
            Question deleteQuestion = dbSet.Find(key);
            context.Answers.RemoveRange(deleteQuestion.Answers);
            dbSet.Remove(deleteQuestion);
        }

        public IEnumerable<Common.Question> GetAll()
        {
            List<Question> allQuestion = dbSet.ToList();
            return Mapper.Map<List<Question>,IEnumerable<Common.Question>>(allQuestion);
        }
        private ICollection<Quiz> UpdateQuizzesList(Question data, List<Quiz> newList)
        {
            ICollection<Quiz> quizzes = data.Quizzes;
            List<Guid> localGuidList = data.Quizzes.Select(q => q.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            foreach (var contextQuizzes in context.Quiz.ToList())
            {
                if (newGuidList.Contains(contextQuizzes.Id))
                {
                    if (!localGuidList.Contains(contextQuizzes.Id))
                    {
                        quizzes.Add(contextQuizzes);
                    }
                }
                else
                {
                    quizzes.Remove(contextQuizzes);
                }
            }

            return quizzes;
        }
        private ICollection<Topic> UpdateTopicList(Question data, List<Topic> newList)
        {
            ICollection<Topic> topics = data.Topics;
            List<Guid> localGuidList = data.Topics.Select(q => q.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            foreach (var contextTopic in context.Topics.ToList())
            {
                if (newGuidList.Contains(contextTopic.Id))
                {
                    if (!localGuidList.Contains(contextTopic.Id))
                    {
                        topics.Add(contextTopic);
                    }
                }
                else
                {
                    topics.Remove(contextTopic);
                }
            }

            return topics;
        }
        private ICollection<Answer> UpdateAnswerList(Question data, List<Answer> newList)
        {
            ICollection<Answer> answers = data.Answers;
            List<Guid> localGuidList = data.Answers.Select(q => q.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            foreach (var contextAnswer in context.Answers.ToList())
            {
                if (newGuidList.Contains(contextAnswer.Id))
                {
                    if (!localGuidList.Contains(contextAnswer.Id))
                    {
                        answers.Add(contextAnswer);
                    }
                }
                else
                {
                    answers.Remove(contextAnswer);
                }
            }

            return answers;
        }
    }
}
