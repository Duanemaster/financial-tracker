# Financial Tracker App

A desktop financial tracking application built using **C# (WinForms)**, **ADO.NET**, and **Microsoft SQL Server**. This application allows users to manage their personal income and expenses with complete CRUD (Create, Read, Update, Delete) functionality, dynamic UI updates, and instant summary metrics.

---

## Features

- **Complete CRUD Operations:**
  - **Create:** Add new transactions (Title, Amount, Category, Type).
  - **Read:** Automatically loads all transactions into a structured `DataGridView`.
  - **Update:** Select any record from the list to modify its details.
  - **Delete:** Remove transactions with a confirmation prompt.
- **Dynamic Dashboard Summary:**
  - Real-time auto-calculation of **Total Income**, **Total Expense**, and **Current Balance**.
- **User Interface Polish:**
  - Formatted currency displays (`₱`).
  - Auto-stretching grid layout with clean alignment.

---

## Tech Stack & Prerequisites

- **Language & Framework:** C# / .NET (WinForms)
- **Database:** Microsoft SQL Server / SSMS
- **Data Access:** ADO.NET (`Microsoft.Data.SqlClient`)

---

## Database Setup Script

To run this project locally, execute the following SQL script in SQL Server Management Studio (SSMS) to create the database, table, and stored procedures:

```sql
CREATE DATABASE FinancialTrackerDB;
GO

USE FinancialTrackerDB;
GO

-- Table Creation
CREATE TABLE Transactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CATEGORY VARCHAR(100),
    TransactionType VARCHAR(20) NOT NULL
);
GO

-- Stored Procedures
CREATE PROCEDURE sp_InsertTransaction
    @Title VARCHAR(100),
    @Amount DECIMAL(18,2),
    @CATEGORY VARCHAR(100),
    @TransactionType VARCHAR(20)
AS
BEGIN
    INSERT INTO Transactions (Title, Amount, CATEGORY, TransactionType)
    VALUES (@Title, @Amount, @CATEGORY, @TransactionType);
END;
GO

CREATE PROCEDURE sp_GetAllTransactions
AS
BEGIN
    SELECT TransactionID, Title, Amount, CATEGORY, TransactionType 
    FROM Transactions 
    ORDER BY TransactionID DESC;
END;
GO

CREATE PROCEDURE sp_UpdateTransaction
    @TransactionID INT,
    @Title VARCHAR(100),
    @Amount DECIMAL(18,2),
    @CATEGORY VARCHAR(100),
    @TransactionType VARCHAR(20)
AS
BEGIN
    UPDATE Transactions
    SET Title = @Title,
        Amount = @Amount,
        CATEGORY = @CATEGORY,
        TransactionType = @TransactionType
    WHERE TransactionID = @TransactionID;
END;
GO

CREATE PROCEDURE sp_DeleteTransaction
    @TransactionID INT
AS
BEGIN
    DELETE FROM Transactions WHERE TransactionID = @TransactionID;
END;
GO
