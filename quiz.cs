using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleQuizApp
{
    class Quiz
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Programming Quiz!");
            Console.WriteLine("You have 20 seconds to answer each question.\n");

            var quizQuestions = new List<Question>
            {
                new Question("What is the purpose of an algorithm in programming?",
                    new List<string>
                    {
                        "A) To represent data visually",
                        "B) To solve a problem or perform a task",
                        "C) To test code for errors",
                        "D) To create a user interface"
                    },
                    'B'),
                new Question("What is the output of 5 % 2 in most programming languages?",
                    new List<string>
                    {
                        "A) 0",
                        "B) 6",
                        "C) 1",
                        "D) 2"
                    },
                    'C'),
                new Question("Which of the following is a compiled programming language?",
                    new List<string>
                    {
                        "A) HTML",
                        "B) Python",
                        "C) JavaScript",
                        "D) C++"
                    },
                    'D'),
                new Question("In object-oriented programming, what does 'inheritance' mean?",
                    new List<string>
                    {
                        "A) A class can acquire properties and behaviors of another class",
                        "B) Functions are passed from one object to another",
                        "C) All methods are automatically inherited by the main program",
                        "D) A class shares its variables with other unrelated classes"
                    },
                    'A'),
                new Question("What does 'debugging' mean in programming?",
                    new List<string>
                    {
                        "A) Testing software with users",
                        "B) Documenting a program",
                        "C) Finding and fixing errors in code",
                        "D) Writing new code"
                    },
                    'C'),
                new Question("What is the main purpose of a 'for loop'?",
                    new List<string>
                    {
                        "A) To test for errors in a code block",
                        "B) To execute a block of code a specific number of times",
                        "C) To run code indefinitely",
                        "D) To run a block of code if a condition is true"
                    },
                    'B'),
                new Question("Which of the following best describes 'recursion'?",
                    new List<string>
                    {
                        "A) Running a loop within another loop",
                        "B) Repeating a process until a condition is false",
                        "C) Returning multiple values from a function",
                        "D) A function calling itself"
                    },
                    'D'),
                new Question("What does the len() function do?",
                    new List<string>
                    {
                        "A) Sums the elements in a list",
                        "B) Finds the maximum in a list",
                        "C) Counts the elements in a list",
                        "D) Sorts the elements in a list"
                    },
                    'C'),
                new Question("Which keyword is used to handle exceptions in Python?",
                    new List<string>
                    {
                        "A) try",
                        "B) catch",
                        "C) handle",
                        "D) error"
                    },
                    'A'),
                new Question("What is the main purpose of version control systems like Git?",
                    new List<string>
                    {
                        "A) To compile code into an executable file",
                        "B) To debug and test software automatically",
                        "C) To design the user interface of an application",
                        "D) To manage changes to code over time"
                    },
                    'D'),
            };

            int score = 0;

            foreach (Question question in quizQuestions)
            {
                Console.WriteLine(question.Text);
                foreach (var option in question.Options)
                {
                    Console.WriteLine(option);
                }

                Console.WriteLine("\nYou have 20 seconds to answer. Enter your answer (A-D): ");

                string userAnswer = null;
                bool answered = false;
                bool timeUp = false;

                // Start the timer thread
                Thread timer = new Thread(() =>
                {
                    Thread.Sleep(20000); // Wait for 20 seconds
                    if (!answered)
                    {
                        timeUp = true; // Mark time as up
                        Console.WriteLine("\nTime's up!");
                        Console.WriteLine($"The correct answer was {question.CorrectAnswer}.\n");
                    }
                });
                timer.Start();

                // Main input loop
                while (!answered && !timeUp)
                {
                    if (Console.KeyAvailable) // Wait for user input
                    {
                        userAnswer = Console.ReadLine()?.ToUpper();

                        if (userAnswer != null && userAnswer.Length == 1 && "ABCD".Contains(userAnswer))
                        {
                            answered = true; // Valid input ends the loop
                            if (userAnswer[0] == question.CorrectAnswer)
                            {
                                Console.WriteLine("\nCorrect!\n");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine($"\nWrong! The correct answer was {question.CorrectAnswer}.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Please enter a valid option (A-D): ");
                        }
                    }

                    if (timeUp) break; // Break if timer signals timeout
                }

                // Ensure timer thread is finished before moving to the next question
                if (!answered && timeUp)
                {
                    timer.Join();
                }
            }

            Console.WriteLine($"You completed the quiz! Your final score is: {score}/{quizQuestions.Count}");
        }
    }

    class Question
    {
        public string Text;
        public List<string> Options;
        public char CorrectAnswer;

        public Question(string text, List<string> options, char correctAnswer)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
