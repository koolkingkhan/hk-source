using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    public interface IRandomQuestionGenerator
    {
        IQuestions GenerateQuestions(int noOfQuestions);
    }
}
