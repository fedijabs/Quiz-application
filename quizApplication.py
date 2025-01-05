import time
from inputimeout import inputimeout, TimeoutOccurred

# Quiz Questions
questions = [
    { #1
        "question": "What is the purpose of an algorithm in programming?",
        "options": ["A) To represent data visually", "B) To solve a problem or perform a task", "C) To test code for errors",
                    "D) To create a user interface"],
        "answer": "B"
    },
    { #2
        "question": "What is the output of 5 % 2 in most programming languages?",
        "options": ["A) 0", "B) 6", "C) 1", "D) 2"],
        "answer": "C"
    },
    { #3
        "question": "Which of the following is a compiled programming language?",
        "options": ["A) HTML", "B) Python", "C) JavaScript", "D) C++"],
        "answer": "D"
    },
    { #4
        "question": "In object-oriented programming, what does 'inheritance' mean?",
        "options": ["A) A class can acquire properties and behaviors of another class", "B) Functions are passed from one object to another",
         "C) All methods are automatically inherited by the main program", "D) A class shares its variables with other unrelated classes"],
        "answer": "A"
    },
    { #5
        "question": "What does 'debugging' mean in programming?",
        "options":["A) Testing software with users", "B) Documenting a program", "C) Finding and fixing errors in code", "D) Writing new code"],
        "answer": "C"
    },
    { #6
        "question": "What is the main purpose of a 'for loop'?",
        "options":["A) To test for errors in a code block", "B) To execute a block of code a specific number of times", 
                "C) To run code indefinitely", "D) To run a block of code if a condition is true"],
        "answer": "B"
    },
    { #7
        "question": "Which of the following best describes 'recursion'?",
        "options":["A) Running a loop within another loop", "B) Repeating a process until a condition is false",
                 "C) Returning multiple values from a function", "D) A function calling itself"],
        "answer": "D"
    },
    { #8
        "question": " What does the len() function do? ",
        "options":["A) Sums the elements in a list", "B) Finds the maximum in a list", "C) Counts the elements in a list ",
                   "D) Sorts the elements in a list"],
        "answer": "C"
    },
    { #9
        "question": " Which keyword is used to handle exceptions in Python? ",
        "options":["A) try", "B) catch", "C) handle ", "D) error"],
        "answer": "A"
    },
    { #10
        "question": " What is the main purpose of version control systems like Git? ",
        "options":["A) To compile code into an executable file", "B) To debug and test software automatically",
                   "C) To design the user interface of an application", "D) To manage changes to code over time"],
        "answer": "D"
    }
]


# Initialize the score
score = 0

# Set time limit for each question (in seconds)
time_limit = 20

# Quiz Introduction
print("Welcome to the Programming Quiz!")
print(f"You have {time_limit} seconds to answer each question.")
print("---------------------\n")

# Quiz Logic
for idx, q in enumerate(questions):
    print(f"Question {idx + 1}: {q['question']}")
    for option in q['options']:
        print(option)
    
    try:
        # Input with a timeout
        user_answer = inputimeout(prompt="Your answer (A, B, C, D): ", timeout=time_limit).strip().upper()
        if user_answer in ["A", "B", "C", "D"]:
            if user_answer == q['answer']:
                print("Correct!\n")
                score += 1
            else:
                print(f"Wrong! The correct answer was {q['answer']}.\n")
        else:
            print(f"Invalid input. The correct answer was {q['answer']}.\n")
    except TimeoutOccurred:
        # Timeout handler
        print(f"Time's up! The correct answer was {q['answer']}.\n")

# Display Final Score
print("---------------------")
print(f"You completed the quiz! Your final score is {score}/{len(questions)}.")
