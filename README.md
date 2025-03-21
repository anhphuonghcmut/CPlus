# 🌐 CPlus Compiler Simulator

## 📝 Overview
CPlus Compiler Simulator is a project that simulates a compiler for a custom programming language called **CPlus**. Built using **C#** and **ANTLR**, this project aims to demonstrate the core components of a compiler, including **lexical analysis, parsing, semantic analysis, and code generation**.

## ✨ Features
- ✅ **Lexical Analysis**: Tokenizes CPlus source code.
- ✅ **Parsing**: Generates an Abstract Syntax Tree (AST) using ANTLR.
- ✅ **Semantic Analysis**: Ensures type correctness and syntax validation.
- ✅ **Intermediate Code Generation**: Translates CPlus into an intermediate representation.
- ✅ **Error Handling**: Provides detailed error messages for syntax and semantic errors.
- ✅ **Extensibility**: Easily expandable for additional language features.

## 🛠️ Technologies Used
- 🔹 **C#**: Primary programming language.
- 🔹 **ANTLR**: Used for lexer and parser generation.
- 🔹 **.NET Core**: Ensures cross-platform compatibility.
- 🔹 **VS Code / Visual Studio**: Recommended IDEs for development.

## 🚀 Getting Started
### 📌 Prerequisites
- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- Install [ANTLR](https://www.antlr.org/)

### 📥 Installation
```sh
# Clone the repository
git clone https://github.com/anhphuonghcmut/CPlus.git
cd CPlus

# Install dependencies
dotnet restore

# Generate ANTLR parser
antlr4 -Dlanguage=CSharp -visitor CPlus.g4 -o Generated

# Build the project or publish to a folder

# Run the compiler with terminal
.\CPlus.exe "{your_file_path}"
```

## 🏗️ Usage
Write your **CPlus** source code in a `.cplus` file and pass it to the compiler:
```cplus
class Test {
  void Main() {
    Print("Welcome to CPlus");
  }
}
```
Run the compiler:
```sh
dotnet run -- input.cplus
```

## 📌 Roadmap
```md
- [ ] 🚀 Implement additional language features (loops, functions, etc.)
- [ ] 🔍 Improve error reporting and debugging tools
- [ ] ⚡ Add optimization passes
- [ ] 🖥️ Generate executable output
```

## 🤝 Contributing
Contributions are welcome! Feel free to open issues and submit pull requests.

## 📜 License
This project is licensed under the **MIT License**.

## 📧 Contact
For questions or discussions, reach out via GitHub Issues.