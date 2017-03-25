using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.GameLogicContracts
{
    public interface ITopicLogic
    {
        void CreateTopic(Topic topic);

        Topic GetTopic(Guid id);

        List<Topic> GetAllTopics();

        void UpdateTopic(Topic topic);

        void DeleteTopic(Guid id);

        Topic CreateTopicAndSendBack(Topic topic);
    }
}
