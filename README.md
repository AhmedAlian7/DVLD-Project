![image](https://github.com/user-attachments/assets/815540e4-884e-4503-8d5a-cef9318a69d5)# Driver License Management System

## Overview
The **Driver License Management System** is a comprehensive application designed to manage driver profiles and facilitate the issuance, renewal, and management of driving licenses. The system provides a user-friendly interface for both administrative users and applicants to efficiently navigate various license-related processes.

## Key Features
### Login and User Management
- **Login Screen**: Secure login functionality for authorized users.
- **User Management**: Create, update, and manage user profiles with secure password management.

### License Management
1. **Application for Licenses**:
   - Apply for an international driving license.
   - Apply for a local driving license.
2. **Renewal**:
   - Renew local licenses with ease.
3. **Replace Lost or Damaged Licenses**:
   - Report and replace lost or damaged licenses.
4. **Release Detained Licenses**:
   - Manage detained licenses and facilitate their release.

### Driver Management
- Maintain and view driver profiles and related information.

### Driving Tests
- **Test Management**:
   - Schedule driving tests for applicants.
   - Take tests and view test results.
- **Test Types**:
   - Manage different types of driving tests.

### License Detention
- Functionality to detain licenses when required and maintain records for the same.

## Technical Stack
- **Frontend**: Developed using C# and Windows Forms.
- **Backend**: Built with .NET Framework, SQL Server, and ADO.NET.
- **Architecture**: Implements a 3-Tier Architecture to separate the following layers:
  1. **Presentation Layer**: Handles the user interface.
  2. **Business Logic Layer**: Manages application logic and rules.
  3. **Data Access Layer**: Handles database operations.

## Project Structure
The project is organized into multiple modules to ensure modularity and maintainability:
- **Applications**: Handles license application processes.
  - Application Types
  - International License
  - Local Driving License
  - Renew Local License
  - Replace Lost or Damaged License
  - Release Detained License
- **Drivers**: Manage driver profiles.
- **Global Classes**: Shared components for reusability.
- **Licenses**: License-related functionalities.
- **Login**: Authentication module.
- **People**: Manage personal information related to drivers and applicants.
- **Tests**: Driving test management.
- **User**: User profile and account management.

## How to Run
1. Clone the repository to your local machine.
2. Set up the database using the provided SQL scripts in the `DVLD_DataAccess` folder.
3. Configure the connection string in the application configuration file.
4. Build and run the solution in Visual Studio.

## Screenshots

### Login Screen
![Login](https://github.com/user-attachments/assets/ba104c4c-7247-495c-b268-ae19da624ac2)

### Main Screen
![Main](https://github.com/user-attachments/assets/7d33d42d-2a59-4ba5-9aee-212d53421a24)

### Manage People
![ManagePeople](https://github.com/user-attachments/assets/70d501e6-59cb-4891-96ec-9982dab4d96d)

### Add New Person
![AddNewPerson](https://github.com/user-attachments/assets/b34308c2-b500-4c58-bf2d-53454e1125b0)
