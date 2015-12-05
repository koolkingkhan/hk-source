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
    """ Student class to represent each student """
    def __init__(self, name):
        self.name = name
        self.scores = []
    
    def add_score(self, score):
        self.scores.append(score)
        
    def highest_score(self):
        return sorted(self.scores, reverse=True)[0]
        
    def average_score(self):
        return sum(self.scores) / float(len(self.scores))
        

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
    
    load_data_from_files()
    
    if get_class_name(student_name) == "class not found":
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
    return "class not found"
    
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
    
    #get the file name to store results in
    results_file = "".join([result_path, class_name, '.csv'])
    
    print("\n")
    print("Storing score in file: ", results_file)
    with open(results_file, 'w', newline="") as csvfile:
        for student in classes[class_name]:
            temp = []
            temp.append(student.name)
            temp.extend(student.scores[-3:]) #Storing last 3 results only as part of Task 3
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
        os.mkdir(result_path)
    else:
        pass


def load_data_from_files():
    """ Loads current data from files
    
    Arguments:
        None
        
    Returns:
        Current data
    """
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
            print("File doesnt currently exist for class: ", class_name, "\n")
    return classes