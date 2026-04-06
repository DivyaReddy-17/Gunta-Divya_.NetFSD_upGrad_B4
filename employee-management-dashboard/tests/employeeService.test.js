//storage setup for employeeService tests.
var employees = [];
var nextId = 1;

var mockStorage = {
  //Return copy of employee list
  getAll: function () { return employees.slice(); },
  // Find employee by ID
  getById: function (id) { return employees.find(function (e) { return e.id === id; }); },
  // Add new employee
  add: function (emp) {
    var rec = Object.assign({}, emp, { id: emp.id || nextId++ });
    employees.push(rec);
    return rec;
  },
  // Update employee
  update: function (id, data) {
    var idx = employees.findIndex(function (e) { return e.id === id; });
    if (idx === -1) return undefined;
    var updated = Object.assign({}, employees[idx], data, { id: id });
    employees[idx] = updated;
    return updated;
  },
  // Remove employee
  remove: function (id) {
    var idx = employees.findIndex(function (e) { return e.id === id; });
    if (idx === -1) return false;
    employees.splice(idx, 1);
    return true;
  },
  nextId: function () { return nextId++; }
};
//Reset Data Before Each Test
beforeEach(function () {
  employees = [
    { id: 1, firstName: 'Alice', lastName: 'Smith', email: 'alice@test.com', phone: '1234567890', department: 'Engineering', designation: 'Dev', salary: 100000, joinDate: '2022-01-01', status: 'Active' },
    { id: 2, firstName: 'Bob', lastName: 'Jones', email: 'bob@test.com', phone: '1234567891', department: 'HR', designation: 'Manager', salary: 150000, joinDate: '2021-06-15', status: 'Active' },
    { id: 3, firstName: 'Carol', lastName: 'Brown', email: 'carol@test.com', phone: '1234567892', department: 'Engineering', designation: 'QA', salary: 80000, joinDate: '2023-01-10', status: 'Inactive' }
  ];
  nextId = 4;
});
//test suite.
describe('employeeService', function () {
  beforeAll(function () {
    global.storageService = mockStorage;
    require('../js/employeeService.js');
  });
  //Get all employees
  test('getAll returns all employees', function () {
    expect(employeeService.getAll().length).toBe(3);
  });

  test('getById returns correct employee', function () {
    var emp = employeeService.getById(2);
    expect(emp).toBeDefined();
    expect(emp.firstName).toBe('Bob');
  });
  // Add new employee
  test('add creates new employee with auto id', function () {
    var added = employeeService.add({ firstName: 'Dave', lastName: 'Lee', email: 'dave@test.com', phone: '1234567893', department: 'Finance', designation: 'Analyst', salary: 90000, joinDate: '2023-05-01', status: 'Active' });
    expect(added.id).toBe(4);
    expect(employeeService.getAll().length).toBe(4);
  });
  //update employee.
  test('update modifies existing employee', function () {
    var updated = employeeService.update(1, { firstName: 'Alicia', designation: 'Senior Dev' });
    expect(updated.firstName).toBe('Alicia');
    expect(updated.designation).toBe('Senior Dev');
  });
  //remove employee.
  test('remove deletes employee', function () {
    var ok = employeeService.remove(2);
    expect(ok).toBe(true);
    expect(employeeService.getById(2)).toBeUndefined();
  });
  //serach by name.
  test('search filters by name case-insensitively', function () {
    var result = employeeService.search('alice');
    expect(result.length).toBe(1);
    expect(result[0].firstName).toBe('Alice');
  });
  //filter by department.
  test('filterByDepartment returns correct subset', function () {
    var result = employeeService.filterByDepartment('Engineering');
    expect(result.length).toBe(2);
  });
  //filter by status.
  test('filterByStatus returns correct subset', function () {
    var result = employeeService.filterByStatus('Inactive');
    expect(result.length).toBe(1);
    expect(result[0].firstName).toBe('Carol');
  });
  //Combined filters (search + dept + status)
  test('applyFilters combines search, dept, status with AND logic', function () {
    var result = employeeService.applyFilters('alice', 'Engineering', 'Active');
    expect(result.length).toBe(1);
  });
  //Sort by name (ascending)
  test('sortBy name asc sorts by lastName', function () {
    var list = employeeService.getAll();
    var sorted = employeeService.sortBy(list, 'name', 'asc');
    expect(sorted[0].lastName).toBe('Brown');
  });
  //Sort by salary (descending)
  test('sortBy salary desc orders highest first', function () {
    var list = employeeService.getAll();
    var sorted = employeeService.sortBy(list, 'salary', 'desc');
    expect(sorted[0].salary).toBe(150000);
  });
  // Email existence check
  test('hasEmail returns true for existing email', function () {
    expect(employeeService.hasEmail('alice@test.com')).toBe(true);
  });
  //Email check with exclusion (for edit case)
  test('hasEmail returns false when excludeId matches', function () {
    expect(employeeService.hasEmail('alice@test.com', 1)).toBe(false);
  });
});
