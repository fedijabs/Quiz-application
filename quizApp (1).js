const readline = require("readline");

// Quiz Questions
const questions = [
  {
    question: "What is the purpose of an algorithm in programming?",
    options: [
      "A) To represent data visually",
      "B) To solve a problem or perform a task",
      "C) To test code for errors",
      "D) To create a user interface",
    ],
    answer: "B",
  },
  {
    question: "What is the output of 5 % 2 in most programming languages?",
    options: ["A) 0", "B) 6", "C) 1", "D) 2"],
    answer: "C",
  },
  {
    question: "Which of the following is a compiled programming language?",
    options: ["A) HTML", "B) Python", "C) JavaScript", "D) C++"],
    answer: "D",
  },
  {
    question: "In object-oriented programming, what does 'inheritance' mean?",
    options: [
      "A) A class can acquire properties and behaviors of another class",
      "B) Functions are passed from one object to another",
      "C) All methods are automatically inherited by the main program",
      "D) A class shares its variables with other unrelated classes",
    ],
    answer: "A",
  },
  {
    question: "What does 'debugging' mean in programming?",
    options: [
      "A) Testing software with users",
      "B) Documenting a program",
      "C) Finding and fixing errors in code",
      "D) Writing new code",
    ],
    answer: "C",
  },
  {
    question: "What is the main purpose of a 'for loop'?",
    options: [
      "A) To test for errors in a code block",
      "B) To execute a block of code a specific number of times",
      "C) To run code indefinitely",
      "D) To run a block of code if a condition is true",
    ],
    answer: "B",
  },
  {
    question: "Which of the following best describes 'recursion'?",
    options: [
      "A) Running a loop within another loop",
      "B) Repeating a process until a condition is false",
      "C) Returning multiple values from a function",
      "D) A function calling itself",
    ],
    answer: "D",
  },
  {
    question: "What does the len() function do?",
    options: [
      "A) Sums the elements in a list",
      "B) Finds the maximum in a list",
      "C) Counts the elements in a list",
      "D) Sorts the elements in a list",
    ],
    answer: "C",
  },
  {
    question: "Which keyword is used to handle exceptions in Python?",
    options: ["A) try", "B) catch", "C) handle", "D) error"],
    answer: "A",
  },
  {
    question: "What is the main purpose of version control systems like Git?",
    options: [
      "A) To compile code into an executable file",
      "B) To debug and test software automatically",
      "C) To design the user interface of an application",
      "D) To manage changes to code over time",
    ],
    answer: "D",
  },
];

// Initialize score
let score = 0;
const timeLimit = 20000; // 20 seconds in milliseconds

// Set up readline interface
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

// Function to ask a question with a timeout
function askQuestion(index) {
  const question = questions[index];
  console.log(`\nQuestion ${index + 1}: ${question.question}`);
  question.options.forEach((option) => console.log(option));

  return new Promise((resolve) => {
    let answered = false;
    const timer = setTimeout(() => {
      if (!answered) {
        console.log(`\nTime's up! The correct answer was ${question.answer}.\n`);
        resolve(false);
      }
    }, timeLimit);

    rl.question("Your answer (A, B, C, D): ", (userAnswer) => {
      clearTimeout(timer);
      answered = true;
      const answer = userAnswer.trim().toUpperCase();
      if (["A", "B", "C", "D"].includes(answer)) {
        if (answer === question.answer) {
          console.log("Correct!\n");
          resolve(true);
        } else {
          console.log(`Wrong! The correct answer was ${question.answer}.\n`);
          resolve(false);
        }
      } else {
        console.log(`Invalid input. The correct answer was ${question.answer}.\n`);
        resolve(false);
      }
    });
  });
}

// Main quiz function
async function quiz() {
  console.log("Welcome to the Programming Quiz!");
  console.log(`You have ${timeLimit / 1000} seconds to answer each question.`);
  console.log("---------------------");

  for (let i = 0; i < questions.length; i++) {
    const correct = await askQuestion(i);
    if (correct) score++;
  }

  console.log("---------------------");
  console.log(`You completed the quiz! Your final score is ${score}/${questions.length}.`);
  rl.close();
}

// Start the quiz
quiz();
