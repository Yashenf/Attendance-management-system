# Smart Attendance System
*A modern desktop application to streamline attendance management for educational institutions.*

![Soft Minimalist Download Laptop Mockup](https://github.com/user-attachments/assets/172d28f6-9d69-4e20-8b07-4d1976954687)

## Project Overview

The **Smart Attendance System** is a modern, user-friendly desktop application designed to streamline attendance management for educational institutions. It enables efficient tracking of student attendance, management of student and subject details, and provides insights into attendance percentages. Built using the .NET Framework and a service-based SQL Server database, the application features a sleek, modern UI implemented as a Windows Form Application.

### Objectives
- To automate attendance tracking for students.
- To manage student profiles, subjects, and user access effectively.
- To record and calculate attendance percentages for each student.
- To provide a simple and intuitive interface for users.

## Key Features
1. **Student Management**: Add, update, and delete student profiles (e.g., name, ID, class).
2. **Subject Management**: Manage subjects (e.g., subject name, code, assigned teacher).
3. **User Management**: Define user roles (e.g., admin, teacher) with appropriate access levels.
4. **Attendance Marking**: Record daily attendance for students per subject with a simple click-based system.
5. **Attendance Percentage View**: Display individual student attendance percentages based on recorded data.
6. **Modern UI**: A clean, visually appealing, and responsive interface for seamless user experience.

## Technologies Used
- **Frontend**: Windows Form Application (.NET Framework) with a modern UI design.
- **Backend**: .NET Framework for business logic and application functionality.
- **Database**: Service-based SQL Server for secure and scalable data storage.
- **Programming Language**: C#.

## Target Users
- **Teachers**: Mark and monitor student attendance.
- **Admins**: Manage students, subjects, and users.
- **Educational Institutions**: Streamline attendance processes.

## Project Scope
- Develop a desktop application for Windows OS.
- Support basic CRUD (Create, Read, Update, Delete) operations for students, subjects, and users.
- Implement attendance tracking and percentage calculation.
- Ensure data persistence using a service-based SQL Server database.

## Installation

1. **Prerequisites**:
   - Windows OS
   - .NET Framework (latest version recommended)
   - SQL Server (service-based)
   - Visual Studio (for development)

2. **Steps**:
   ```bash
   git clone https://github.com/Yashenf/Attendance-management-system.git
   cd Attendance-management-system


   
---

### Key UIs
Menu Based Navigation System

## Screenshots
| Sign-In Screen | Home Screen | Subject Management |
|----------------|-------------|--------------------|
| ![Screenshot (150)](https://github.com/user-attachments/assets/361308eb-3000-41b7-9d1a-941a23fb984e) | ![Screenshot (161)](https://github.com/user-attachments/assets/a860aa7f-2d21-4b95-9934-fdb1e03174c8) | !![Screenshot (160)](https://github.com/user-attachments/assets/8f6c51c0-b932-4a2a-8d63-fd298ab2a6f2)|

## Challenges & Solutions

1. **Database Not Working Properly**:
   - *Issue*: Connectivity or functionality issues with SQL Server.
   - *Solution*: Updated Visual Studio and .NET Framework to the latest versions, resolving compatibility problems.

2. **Menu Screen Form Loading Issue**:
   - *Issue*: Forms failed to load into the Home Screen’s container panel.
   - *Solution*: Researched StackOverflow; implemented proper form instantiation and docking (e.g., `TopLevel = false`, `Dock = DockStyle.Fill`).

3. **Attendance Percentage Update with SMS Integration**:
   - *Issue*: SMS providers required paid packages, which were cost-prohibitive.
   - *Solution*: Focused on in-app percentage calculation; deferred SMS integration for future updates with free-tier APIs or email alternatives.
  
## Deliverables
- Fully functional Smart Attendance System application.
- Source code with inline documentation.
- User manual for operating the system.
- Database schema and setup instructions.

## Timeline
- **Duration**: 4-6 weeks
- **Milestones**:
  1. **Week 1**: Requirement analysis and database design.
  2. **Week 2**: UI design and setup.
  3. **Weeks 3-4**: Core functionality development (student/subject/user management, attendance marking).
  4. **Week 5**: Attendance percentage calculation and testing.
  5. **Week 6**: Final UI polish, bug fixing, and deployment.

## Future Enhancements
- Integration with biometric devices for automated attendance.
- Export attendance reports to PDF/Excel.
- Cloud-based database for remote access.

## Contributors
| Reg.No       | Name              | Role                  |
|--------------|-------------------|-----------------------|
| 2021/ICTS/153| Mr. Yashen Fernando | Developer            |

### Special Thanks
Special thanks goes to **Mr. Abiramithan**, Lecturer in charge of Advanced Computer Programming Practicals, for his guidance and support throughout the project.

## License
This project is licensed under the [MIT License](LICENSE).

## References
- GitHub Repository: [https://github.com/Yashenf/Attendance-management-system](https://github.com/Yashenf/Attendance-management-system)
