"""
Nishat H.
Computing Coursework
Task 2: Score Tracker
"""
import os
import csv 

#Results folder path
result_path = "quiz_results/"

class Student:
    def __init__(self, name):
        self.name = name
        self.scores = []
    
    def add_score(self, score):
        self.scores.append(score)
        

#Create a dict of class names to the sets of students defined above
classes = {"lion" : [], "tiger" : [], "zebra" : []}


#Tuples are created using parentheses, i.e. ("a","b","c"). But we are not using them in this program

def determine_class(student_name):
    """ Determines the class the student is in. If the student is not found then they are using the program for the 
    first time. A new entry is created for them upon their first run of the Arithmetic Quiz.
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        None
    """
    
    read_from_file()
    
    if not student_exists(student_name):
        print("You are not currently registered in the system.")
        while True:    
            className = input("What class are you in (lion,tiger or zebra)? ").lower()                
            if (className in classes.keys()):
                student = Student(student_name)
                classes[className].append(student)
                break
            else:
                print("You have not entered a valid class name")
    else:
        pass
            
     
def student_exists(student_name):
    for students in classes.values():
        if (any(str(x.name) == student_name for x in students)):
            return True
        else:
            pass
    return False
     
def get_class_name(student_name):
    """ Calculates the class the student is in from the existing stored data. If the student is not found a blank class name is returned
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        The name of the class the student is in
    """
    for name, students in classes.items():
        if (any(str(x.name) == student_name for x in students)):
            return name
        else:
            pass
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
    class_name = get_class_name(student_name)
    
    index = [ x.name for x in classes[class_name] ].index(student_name)
    classes[class_name][index].add_score(score)
    print("Student in class ", class_name)
    results_file = get_student_file_name(student_name, class_name)
    
    print("\n")
    print("Storing score in file: ", results_file)
    with open(results_file, 'w', newline="") as csvfile:
        for student in classes[class_name]:
            temp = []
            temp.append(student.name)
            temp.extend(student.scores)
            print(temp)
            resultswriter = csv.writer(csvfile, delimiter =',', quoting=csv.QUOTE_NONE)
            resultswriter.writerow(temp)
    
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

def get_student_file_name(student_name, class_name):
    """ Gets the appropriate results file for the current student
    
    Arguments:
        student_name: The name of the student
        
    Returns:
        The results file name
    """
    #get the file name to store results in
    return "".join([result_path, class_name, '.csv'])

def read_from_file():
    for class_name in classes.keys():
        try:
            file = "".join([result_path, class_name, '.csv'])        
            with open(file, 'r') as csvfile:
                reader = csv.reader(csvfile, delimiter=",",quoting=csv.QUOTE_NONE)
                for row in reader:
                    col_number = 0
                    for col in row:
                        if col_number == 0:
                            student = Student(col.strip())
                        else:
                            student.add_score(float(col.strip()))
                        col_number += 1             
                    classes[class_name].append(student)
        except (OSError, IOError) as ex:
            print("File doesnt currently exist for class: ", class_name)