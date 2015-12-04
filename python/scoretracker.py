"""
Nishat H.
Computing Coursework
Task 2: Score Tracker
"""
import os
import csv 

#Results folder path
resultsPath = "results/"

#Create a set to store students. Sets are also defined using curly braces, the empty set is defined by set().
#Sets are unordered and unique
class1 = {"nishat"}
class2 = set()
class3 = set()

#Create a dict of class names to the sets of students defined above
classes = {"lion" : class1, "tiger" : class2, "zebra" : class3}


#Tuples are created using parentheses, i.e. ("a","b","c"). But we are not using them in this program
def determine_class(student_name):
    """ Determines the class the student is in. If the student is not found they are using the program for the 
    first time and are then stored in a class
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        None
    """
    if not (student_name in class1 or student_name in class2 or student_name in class3):
        print("You are not currently registered in the system.")
        while True:    
            className = input("What class are you in (lion,tiger or zebra)? ").lower()                
            if (className in classes.keys()):
                classes[className].add(student_name)
                break
            else:
                print("You have not entered a valid class name")
    else:
        pass
            

def get_class_name(student_name):
    """ Calculates the class the student is in. If the student is not found a blank class name is returned
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        The name of the class the student is in
    """
    for name, students in classes.items():
        if student_name in students:
            return name
    return ""
    
def store_result(student_name, score):
    """ Stores the score of the specified in a file named after the class he is in
    
    Arguments:
        student_name: The name of the student
        score: The score obtained from the quiz
        
    Returns:
        None
    """
    create_directory()
    
    #get the file name to store results in
    resultsFile = "".join([resultsPath, get_class_name(student_name), '.csv'])
    
    print("Storing score in file: ", resultsFile)
    with open(resultsFile, 'w', newline='') as csvfile:
        resultswriter = csv.writer(csvfile, delimiter=',')
        resultswriter.writerow([student_name, score])
    
def create_directory():
    """ Create the results folder to store the score for the student
    
    Arguments:
        None
        
    Returns:
        None
    """
    if not os.path.exists(resultsPath):
        print("Creating directory", os.getcwd(), resultsPath)
        os.mkdir(resultsPath)
    else:
        print("Found results directory")