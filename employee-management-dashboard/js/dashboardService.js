
(function (global) {
  // Get reference to employeeService if available, otherwise set to null

  var empSvc = typeof employeeService !== 'undefined' ? employeeService : null;
  // Get overall employee summary
  function getSummary() {
    // Fetch all employees (fallback to empty array if service not available)
    var all = empSvc ? empSvc.getAll() : [];
    // Count active employees
    var active = all.filter(function (e) { return e.status === 'Active'; }).length;
    // Count inactive employees
    var inactive = all.filter(function (e) { return e.status !== 'Active'; }).length;
    // Collect unique departments using an object (acts like a set)
    var depts = {};
    all.forEach(function (e) {
      if (e.department) depts[e.department] = true;
    });
    // Return summary object
    return {
      total: all.length,
      active: active,
      inactive: inactive,
      departments: Object.keys(depts).length
    };
  }

  //Get employee count grouped by department
  function getDepartmentBreakdown() {
    // Fetch all employees
    var all = empSvc ? empSvc.getAll() : [];
    var map = {};
    // Loop through employees and count per department
    all.forEach(function (e) {
      var d = e.department || 'Unknown';
      map[d] = (map[d] || 0) + 1;
    });
    return map;
  }
  //Get most recent employees based on highest ID
  function getRecentEmployees(n) {
    var all = empSvc ? empSvc.getAll() : [];
    return all.slice().sort(function (a, b) { return (b.id || 0) - (a.id || 0); }).slice(0, n || 5);
  }
  // Expose functions globally as dashboardService
  global.dashboardService = {
    getSummary: getSummary,
    getDepartmentBreakdown: getDepartmentBreakdown,
    getRecentEmployees: getRecentEmployees
  };
})(typeof window !== 'undefined' ? window : global);
