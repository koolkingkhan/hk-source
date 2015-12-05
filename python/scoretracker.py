"""
Nishat H.
Computing Coursework
Task 2: Score Tracker
"""
import os
import csv 

#Results folder path
result_path = "quiz_results/"

#Create a set to store students. Sets are also defined using curly braces, the empty set is defined by set().
#Sets are unordered and unique
class1 = {"nishat"}
class2 = set()
class3 = set()

#Create a dict of class names to the sets of students defined above
classes = {"lion" : class1, "tiger" : class2, "zebra" : class3}


#Tuples are created using parentheses, i.e. ("a","b","c"). But we are not using them in this program

def determine_class(student_name):
    """ Determines the class the student is in. If the student is not found then they are using the program for the 
    first time. A new entry is created for them upon their first run of the Arithmetic Quiz.
    
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
        read_from_file(student_name)
            

def get_class_name(student_name):
    """ Calculates the class the student is in from the existing stored data. If the student is not found a blank class name is returned
    
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
    results_file = get_student_file_name(student_name)
    
    #Using the csv module
    #http://www.pythonforbeginners.com/systems-programming/using-the-csv-module-in-python/
    print("Storing score in file: ", results_file)
    with open(results_file, 'w', newline='') as csvfile:
        resultswriter = csv.writer(csvfile, delimiter=',')
        resultswriter.writerow([student_name, score])
    
def create_directory():
    """ Create the results folder to store the score for the student
    
    Arguments:
        None
        
    Returns:
        None
    """
    if not os.path.exists(result_path):
        print("Creating directory", os.getcwd(), result_path)
        os.mkdir(result_path)
    else:
        print("Found results directory")

def get_student_file_name(student_name):
    """ Gets the appropriate results file for the current student
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        The results file name
    """
    #get the file name to store results in
    return "".join([result_path, get_class_name(student_name), '.csv'])

def read_from_file(student_name):
    results_file = get_student_file_name(student_name)
    with open(results_file, 'r') as csvfile:
        reader = csv.reader(csvfile)
        for row in reader:
            print(row)