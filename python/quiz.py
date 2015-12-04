import random
import operator

#We create a dictionary defined as dict, for storing operators. A dictionary is a list of key-value pairs, separated by the colon and placed inside curly braces
#e.g "+" is the key, operator.add is the value
#Dictionaries do not store values in the order inserted
operators = {"+" : operator.add, "-" : operator.sub, "*" : operator.mul }
operator_keys = list(operators)

#Create a set to store students. Sets are also defined using curly braces, the empty set is defined by set().
#Sets are unordered and unique
class1 = {"nishat"}
class2 = set()
class3 = set()

#Create a dict of class names to the sets of students defined above
classes = {"lion" : class1, "tiger" : class2, "zebra" : class3}

#Tuples are created using parentheses, i.e. ("a","b","c"). But we are not using them in this program


def main():
    noOfQuestionsToAsk = 10
    name = input("Enter your name:").lower()
    
    if (name not in class1 or name not in class2 or name not in class3):
        print("You are not currently registered in the system.")
        while True:    
            className = input("What class are you in (lion,tiger or zebra)? ").lower()                
            if (className in classes.keys()):
                classes[className].add(name)
                break
            else:
                print("You have not entered a valid class name")
        
    #Formatting the output, {} are replaced by each variable, i.e. name and noOfQuestionsToAsk
    print("Hello {}, you will be asked {} questions".format(name, noOfQuestionsToAsk))
    
    correctlyAnswered = 0
    #Start value = 1, stop value = 10+1 = 11
    #We add 1 to the stop value as we want to ask 10 questions in total, the stop value in the range is not included,
    #i.e. for questionNo in range(1,10), start value is 1, so it runs from 1 to 9 and stops at 10 
    for questionNo in range(1, noOfQuestionsToAsk+1): 
        #Print on a new line using \n in the string
        print("\n")
        #Add one to output as the range begines 
        print("Question ", questionNo)
        #ask_random_question returns a boolean indicating whether the student answer was correct
        if (ask_random_question()):
            correctlyAnswered += 1
    
    print("\n")
    print("You have correctly answered {} out of {} questions".format(correctlyAnswered, noOfQuestionsToAsk))
    score = (correctlyAnswered / noOfQuestionsToAsk) * 100
    print("With a score of: {}%".format(score))

def ask_random_question():
    operator = random.choice(operator_keys)
    fistNumber = random.randint(1,11)
    secondNumber = random.randint(1,11)
    
    #While loop with exception handling to check for bad input. Using try/except construct
    while True:    
        print("What does {} {} {} equal to?".format(fistNumber,operator, secondNumber))
        studentAnswer = convert(input("Enter your answer: "))
        if(studentAnswer != "conversion error"):
            break
        
    #Validate answer, we access the operator value by the key we pass in
    #e.g operator.add(3,5)
    if studentAnswer == (operators[operator](fistNumber, secondNumber)):
        print("That is correct, well done!")
        return True
    else:
        print("Incorrect!")
        return False


def convert(s):
    try:
        x = int(s)
    except ValueError as ex:
        print("Invalid input, try again") 
        x = "conversion error"
    return x   
        
        
#Run the program from the REPL
#This is importable and executable        
if __name__ == '__main__':
    main()
    
