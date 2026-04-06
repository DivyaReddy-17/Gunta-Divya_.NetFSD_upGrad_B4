//it acts as a data store for employee records.
(function (global) {
  // Internal employee array (acts like a database)
  var employees = [];
  // Tracks the highest ID to generate unique IDs
  var maxId = 0;
  // Initialize with seed data if available that is employee data.
  function init() {
    if (typeof employeeData !== 'undefined' && Array.isArray(employeeData)) {
      // Deep copy of employeeData into internal array
      employees = employeeData.map(function (e) { return Object.assign({}, e); });
      // Find highest existing ID
      employees.forEach(function (e) {
        if (e.id > maxId) maxId = e.id;
      });
    }
  }
  init();
  //get all employees.
  function getAll() {
    return employees;
  }
  //get employee by id
  function getById(id) {
    return employees.find(function (e) { return e.id === id; });
  }
    //add new employee record
    function add(employee) {
    // Use existing ID or generate new one
    var id = employee.id != null ? employee.id : nextId();
    // Create new record (avoid direct mutation)
    var record = Object.assign({}, employee, { id: id });
    // Add to storage
    employees.push(record);
    // Update maxId if necessary
    if (id > maxId) maxId = id;
    return record;
  }
  /*Update employee by ID
   Merges old data with new data
   */
  function update(id, data) {
     // Find index of employee
    var idx = employees.findIndex(function (e) { return e.id === id; });
    if (idx === -1) return undefined;
     // Merge old record with updated fields
    var updated = Object.assign({}, employees[idx], data, { id: id });
    employees[idx] = updated;
    return updated;
  }
  //remove employee by id
  function remove(id) {
    var idx = employees.findIndex(function (e) { return e.id === id; });
    if (idx === -1) return false;
    // Remove from array
    employees.splice(idx, 1);
    return true;
  }
  //Generate next unique ID
  function nextId() {
    maxId += 1;
    return maxId;
  }
  // Expose service globally as storageService
  global.storageService = {
    getAll: getAll,
    getById: getById,
    add: add,
    update: update,
    remove: remove,
    nextId: nextId
  };
})(typeof window !== 'undefined' ? window : global);
