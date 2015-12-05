"""
Nishat H.
Computing Coursework
Task 3: Performance tracker
"""

#Import all functions from scoretracker.py
from scoretracker import *

def main():
    data = load_data_from_files()
    #pretty_print_results(data)
    #pretty_print_results_by_highest_score(data)
    pretty_print_results_by_average_score(data)


def pretty_print_results(data):
    print("Printing results in alphabetical order showing their highest score")
    for class_name, students in data.items():
        print("Class: ", class_name)
        students.sort(key=lambda x: x.name)
        for student in students:
            student.scores.sort(reverse=True)
            print("Student: {}, Highest Score: {}".format(student.name, student.scores[0]))
        print("\n")
            
def pretty_print_results_by_highest_score(data):
    print("Printing results by highest score")
    for class_name, students in data.items():
        print("Class: ", class_name)
        
        students.sort(key=lambda x: x.highest_score(), reverse=True)
        for index in range(len(students)):
            student = students[index]
            if index == 0:
                print("Highest Scoring Student: {}, Score: {}".format(student.name, student.highest_score()))
            elif index == len(students)-1:
                print("Lowest Scoring Student: {}, Score: {}".format(student.name, student.highest_score()))
            else:
                print("Name: {}, Score: {}".format(student.name, student.highest_score()))
        print("\n")
        
def pretty_print_results_by_average_score(data):
    print("Printing results by average score")
    for class_name, students in data.items():
        print("Class: ", class_name)
        
        students.sort(key=lambda x: x.average_score(), reverse=True)
        for index in range(len(students)):
            student = students[index]
            if index == 0:
                print("Student with highest average: {}, Score: {}".format(student.name, student.average_score()))
            elif index == len(students)-1:
                print("Student with lowest average: {}, Score: {}".format(student.name, student.average_score()))
            else:
                print("Name: {}, Score: {}".format(student.name, student.average_score()))
        print("\n")

    
#Run the program from the command line using "python performancetracker.py"
#This is importable and executable        
if __name__ == '__main__':
    main()