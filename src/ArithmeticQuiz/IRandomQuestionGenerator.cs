using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticQuiz
{
    public interface IRandomQuestionGenerator
    {
        List<IQuestion> GenerateQuestions(int noOfQuestions);
    }
}
