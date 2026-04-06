/*List of all employees in the system
 Each object represents one employee record*/
var employeeData = [
 { id: 1, firstName: 'Aarav', lastName: 'Mehta', email: 'aarav.mehta@XYZ.com', phone: '9876500001', department: 'Engineering', designation: 'Software Engineer', salary: 720000, joinDate: '2021-02-15', status: 'Active' },
  { id: 2, firstName: 'Nisha', lastName: 'Shah', email: 'nisha.shah@XYZ.com', phone: '9876500002', department: 'Marketing', designation: 'Marketing Specialist', salary: 650000, joinDate: '2022-07-20', status: 'Active' },
  { id: 3, firstName: 'Rohan', lastName: 'Iyer', email: 'rohan.iyer@XYZ.com', phone: '9876500003', department: 'HR', designation: 'HR Executive', salary: 580000, joinDate: '2023-01-05', status: 'Inactive' },
  { id: 4, firstName: 'Simran', lastName: 'Patel', email: 'simran.patel@XYZ.com', phone: '9876500004', department: 'Finance', designation: 'Financial Analyst', salary: 700000, joinDate: '2021-10-10', status: 'Active' },
  { id: 5, firstName: 'Karan', lastName: 'Gupta', email: 'karan.gupta@XYZ.com', phone: '9876500005', department: 'Operations', designation: 'Operations Lead', salary: 680000, joinDate: '2020-12-22', status: 'Active' },
  { id: 6, firstName: 'Tanya', lastName: 'Rao', email: 'tanya.rao@XYZ.com', phone: '9876500006', department: 'Engineering', designation: 'Senior Developer', salary: 900000, joinDate: '2019-06-15', status: 'Active' },
  { id: 7, firstName: 'Vivek', lastName: 'Bhat', email: 'vivek.bhat@XYZ.com', phone: '9876500007', department: 'Marketing', designation: 'Content Writer', salary: 550000, joinDate: '2022-03-18', status: 'Inactive' },
  { id: 8, firstName: 'Ananya', lastName: 'Joshi', email: 'ananya.joshi@XYZ.com', phone: '9876500008', department: 'HR', designation: 'Recruiter', salary: 540000, joinDate: '2023-04-12', status: 'Active' },
  { id: 9, firstName: 'Aditya', lastName: 'Kumar', email: 'aditya.kumar@XYZ.com', phone: '9876500009', department: 'Finance', designation: 'Accountant', salary: 600000, joinDate: '2020-08-01', status: 'Active' },
  { id: 10, firstName: 'Isha', lastName: 'Menon', email: 'isha.menon@XYZ.com', phone: '9876500010', department: 'Operations', designation: 'Logistics Coordinator', salary: 520000, joinDate: '2021-11-30', status: 'Inactive' },
  { id: 11, firstName: 'Dhruv', lastName: 'Sharma', email: 'dhruv.sharma@XYZ.com', phone: '9876500011', department: 'Engineering', designation: 'QA Engineer', salary: 650000, joinDate: '2022-09-05', status: 'Active' },
  { id: 12, firstName: 'Megha', lastName: 'Reddy', email: 'megha.reddy@XYZ.com', phone: '9876500012', department: 'Marketing', designation: 'Digital Marketing Specialist', salary: 620000, joinDate: '2022-12-10', status: 'Active' },
  { id: 13, firstName: 'Shiv', lastName: 'Nair', email: 'shiv.nair@XYZ.com', phone: '9876500013', department: 'HR', designation: 'HR Manager', salary: 880000, joinDate: '2019-05-20', status: 'Active' },
  { id: 14, firstName: 'Riya', lastName: 'Bhatia', email: 'riya.bhatia@XYZ.com', phone: '9876500014', department: 'Finance', designation: 'Tax Specialist', salary: 780000, joinDate: '2021-07-25', status: 'Active' },
  { id: 15, firstName: 'Siddharth', lastName: 'Rao', email: 'siddharth.rao@XYZ.com', phone: '9876500015', department: 'Operations', designation: 'Supply Chain Manager', salary: 820000, joinDate: '2020-11-28', status: 'Active' }
];
/*Default admin login credentials
Used for initial authentication setup*/
var adminCredentialsSeed = {
  username: 'admin',
  password: 'admin123'
};
