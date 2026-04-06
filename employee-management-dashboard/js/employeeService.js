/*
Employee business logic.
Provides search, filter, sort, and CRUD functionalities*/
(function (global) {
    // Reference to storageService (data access layer)
  var store = typeof storageService !== 'undefined' ? storageService : null;
  //get underlying storage service.
  function getStore() {
    return store;
  }
  //Get all employee record
  function getAll() {
    return store ? store.getAll() : [];
  }
  //get employee by id
  function getById(id) {
    return store ? store.getById(id) : undefined;
  }
  /*
   Add new employee
   Generates unique ID
   Cleans phone number (digits only, max 10)
   Ensures salary is numeric
   */
    function add(data) {
    if (!store) return null;
    var id = store.nextId();
    var record = {
      id: id,// Auto-generated ID
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      // Keep only digits and limit to 10 characters
      phone: String(data.phone).replace(/\D/g, '').slice(0, 10),
      department: data.department,
      designation: data.designation,
      // Convert salary to number
      salary: Number(data.salary),
      joinDate: data.joinDate,
      status: data.status
    };
    return store.add(record);
  }
   /*Update existing employee
   Cleans phone and salary like add()
   */
    function update(id, data) {
    if (!store) return undefined;
    var payload = {
      
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      phone: String(data.phone).replace(/\D/g, '').slice(0, 10),
      department: data.department,
      designation: data.designation,
      salary: Number(data.salary),
      joinDate: data.joinDate,
      status: data.status
    };
    return store.update(id, payload);
  }
  //removes employee by id
  function remove(id) {
    return store ? store.remove(id) : false;
  }
  // Checks if email already exists (excluding a specific ID for updates)
  function hasEmail(email, excludeId) {
    var all = getAll();
    var found = all.find(function (e) {
      return e.email && e.email.toLowerCase() === String(email).toLowerCase() && e.id !== excludeId;
    });
    return !!found;
  }
  //search employee by name or email.
  function search(query, list) {
    var q = String(query || '').toLowerCase().trim();
    if (!q) return list || getAll();
    var arr = list || getAll();
    return arr.filter(function (e) {
      var fullName = (e.firstName + ' ' + e.lastName).toLowerCase();
      var email = (e.email || '').toLowerCase();
      return fullName.indexOf(q) !== -1 || email.indexOf(q) !== -1;
    });
  }
  //filter employee by department
  function filterByDepartment(dept, list) {
    if (!dept) return list || getAll();
    var arr = list || getAll();
    return arr.filter(function (e) { return e.department === dept; });
  }
    //filter employee by status
  function filterByStatus(status, list) {
    if (!status) return list || getAll();
    var arr = list || getAll();
    return arr.filter(function (e) { return e.status === status; });
  }
/* apply multiple filters together (search, department, status) */  
  function applyFilters(searchQuery, dept, status) {
    var result = getAll();
    result = search(searchQuery, result);
    result = filterByDepartment(dept, result);
    result = filterByStatus(status, result);
    return result;
  }
  //Sort employee list.
  function sortBy(list, field, direction) {
    var arr = list ? list.slice() : getAll().slice();
    var asc = direction !== 'desc';
    //sort by last name
    if (field === 'name') {
      arr.sort(function (a, b) {
        var la = (a.lastName || '').toLowerCase();
        var lb = (b.lastName || '').toLowerCase();
        var cmp = la.localeCompare(lb);
        return asc ? cmp : -cmp;
      });
      //sort by salary
    } else if (field === 'salary') {
      arr.sort(function (a, b) {
        var sa = Number(a.salary) || 0;
        var sb = Number(b.salary) || 0;
        return asc ? sa - sb : sb - sa;
      });
      //sort by join date
    } else if (field === 'date') {
      arr.sort(function (a, b) {
        var da = a.joinDate || '';
        var db = b.joinDate || '';
        var cmp = da.localeCompare(db);
        return asc ? cmp : -cmp;
      });
    }
    return arr;
  }
  //Expose service globally.
  global.employeeService = {
    getAll: getAll,
    getById: getById,
    add: add,
    update: update,
    remove: remove,
    hasEmail: hasEmail,
    search: search,
    filterByDepartment: filterByDepartment,
    filterByStatus: filterByStatus,
    applyFilters: applyFilters,
    sortBy: sortBy,
    getStore: getStore
  };
})(typeof window !== 'undefined' ? window : global);