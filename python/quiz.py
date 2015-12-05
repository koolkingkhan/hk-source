"""
Nishat H.
Computing Coursework
Task 1: Arithmentic Quiz
"""
import random
import operator
import os

from scoretracker import *

#We create a dictionary defined as dict, for storing operators. A dictionary is a list of key-value pairs, separated by the colon and placed inside curly braces
#e.g "+" is the key, operator.add is the value
#Dictionaries do not store values in the order inserted
operators = {"+" : operator.add, "-" : operator.sub, "*" : operator.mul }
operator_keys = list(operators)
no_of_questions = 10


def main():
    """ Main body of program. This should be used as the entry point.
    It controls the flow of the program and creates a loop of 10 questions to ask to the user.
    
    Arguments:
        None
        
    Returns:
        None
    """
        
    name = input("Enter your name: ").strip().lower()
    determine_class(name)
    
    #Formatting the output, {} are replaced by each variable, i.e. name and no_of_questions
    print("Hello {}, you will be asked {} questions".format(name, no_of_questions))
    
    correctly_answered = 0
    #Start value = 1, stop value = 10+1 = 11
    #We add 1 to the stop value as we want to ask 10 questions in total, the stop value in the range is not included,
    #i.e. for questionNo in range(1,10), start value is 1, so it runs from 1 to 9 and stops at 10 
    for questionNo in range(1, no_of_questions+1): 
        #Print on a new line using \n in the string
        print("\n")
        #Add one to output as the range begines 
        print("Question ", questionNo)
        #ask_random_question returns a boolean indicating whether the student answer was correct
        if (ask_random_question()):
            correctly_answered += 1
    
    print("\n")
    print("You have correctly answered {} out of {} questions".format(correctly_answered, no_of_questions))
    score = (correctly_answered / no_of_questions) * 100
    print("With a score of: {}%".format(score))
    store_result(name, score)

def ask_random_question():
    """ Asks a single random question to the user
    Arguments:
        None
        
    Returns:
        Returns True or False depending on whether the user answered the question correctly
    """
    operator = random.choice(operator_keys)
    first_number = random.randint(1,11)
    second_number = random.randint(1,11)
    
    #While loop with exception handling to check for bad input. Using try/except construct
    while True:    
        print("What does {} {} {} equal to?".format(first_number,operator, second_number))
        studentAnswer = convert(input("Enter your answer: "))
        if(studentAnswer != "conversion error"):
            break
        
    #Validate answer, we access the operator value by the key we pass in
    #e.g operator.add(3,5)
    if studentAnswer == (operators[operator](first_number, second_number)):
        print("That is correct, well done!")
        return True
    else:
        print("Incorrect!")
        return False


def convert(s):
    """ Provides a safe way to convert a string to an integer
    Arguments:
        s: Value to convert
        
    Returns:
        An integer converted from the argument s. If conversion fails returns string "conversion error"
    """
    try:
        x = int(s)
    except ValueError as ex:
        print("Invalid input, try again") 
        x = "conversion error"
    return x        
        
#Run the program from the command line using "python quiz.py"
#This is importable and executable        
if __name__ == '__main__':
    main()
    
