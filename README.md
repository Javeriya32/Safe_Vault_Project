# Safe_Vault_Project
# SafeVault – Secure Web Application

## Overview
SafeVault is a secure ASP.NET Core Web API application designed to manage sensitive user data such as credentials and role-based access to protected resources. The primary goal of this project is to demonstrate secure coding practices, authentication and authorization mechanisms, vulnerability mitigation, and security testing using Microsoft Copilot.

The application was developed as part of a secure development and DevOps coursework project and focuses on preventing common web vulnerabilities such as SQL injection and cross-site scripting (XSS).

---

## Key Features

### 1. Secure Input Handling
- All user inputs are sanitized and validated to prevent malicious payloads.
- Protection against XSS using HTML encoding and script removal.

### 2. SQL Injection Prevention
- All database queries use parameterized SQL commands.
- No raw string concatenation is used in queries.

### 3. Authentication
- Users authenticate using securely hashed passwords.
- Passwords are hashed using BCrypt with a strong work factor.

### 4. Role-Based Authorization (RBAC)
- Users are assigned roles such as `User` or `Admin`.
- Sensitive routes are protected using role-based access checks.

### 5. Security Middleware
- Custom middleware adds HTTP security headers.
- Prevents clickjacking, MIME sniffing, and basic XSS exploits.

### 6. Automated Security Testing
- Unit tests simulate SQL injection attempts.
- Unit tests validate XSS protection.
- Authentication and authorization flows are verified.

---

## Technologies Used
- ASP.NET Core Web API (.NET 8)
- SQLite
- BCrypt for password hashing
- NUnit for testing
- Microsoft Copilot for secure code generation and review

---

## How to Run
1. Clone the repository
2. Restore dependencies
3. Run the API project
4. Execute tests using `dotnet test`

---

## Security Summary
This project applies defense-in-depth by combining secure coding, authentication, authorization, middleware protections, and automated testing to ensure the SafeVault application is resilient against common attack vectors.
