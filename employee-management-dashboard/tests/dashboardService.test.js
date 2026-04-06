//mock employee data.
var mockEmployees = [];

beforeAll(function () {
  // Create mock employee data
  mockEmployees = [
    { id: 1, firstName: 'A', lastName: 'A', department: 'Engineering', status: 'Active' },
    { id: 2, firstName: 'B', lastName: 'B', department: 'HR', status: 'Active' },
    { id: 3, firstName: 'C', lastName: 'C', department: 'Engineering', status: 'Inactive' },
    { id: 4, firstName: 'D', lastName: 'D', department: 'Finance', status: 'Active' }
  ];
  /*Mock employeeService
  Provides controlled data to dashboardService
  Ensures tests are independent of real data layer*/
  global.employeeService = {
    getAll: function () 
    { return mockEmployees.slice(); }// Return a copy to prevent mutation
  };
  // Load dashboardService after mocking dependencies
  require('../js/dashboardService.js');
});

  describe('dashboardService', function () {
/*Summary calculation
Validates total, active, inactive counts
Validates unique department count
*/
  test('getSummary returns correct counts', function () {
    var s = dashboardService.getSummary();
    expect(s.total).toBe(4);
    expect(s.active).toBe(3);
    expect(s.inactive).toBe(1);
    expect(s.departments).toBe(3);
  });
  //Department breakdown calculation
  test('getDepartmentBreakdown returns per-dept counts', function () {
    var b = dashboardService.getDepartmentBreakdown();
    expect(b.Engineering).toBe(2);
    expect(b.HR).toBe(1);
    expect(b.Finance).toBe(1);
  });
  //Recent employees retrieval.
  test('getRecentEmployees returns last n by highest id', function () {
    var recent = dashboardService.getRecentEmployees(2);
    expect(recent.length).toBe(2);
    expect(recent[0].id).toBe(4);
    expect(recent[1].id).toBe(3);
  });
});
