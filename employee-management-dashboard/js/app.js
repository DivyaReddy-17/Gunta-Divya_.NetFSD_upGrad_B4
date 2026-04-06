/*App state(filtering and sorting)*/
$(function () {
  var state = {
    searchQuery: '',
    filterDept: '',
    filterStatus: '',
    sortField: 'id',
    sortDir: 'asc'
  };
  // Show login/signup screen

  function showAuthView() {
    $('#mainNavbar').hide();
    $('#dashboardView').hide();
    $('#authView').show();
    $('#loginView').show();
    $('#signupView').hide();
  }

// Show dashboard after login
  function showDashboardView() {
    $('#authView').hide();
    $('#mainNavbar').show();
    $('#dashboardView').show();
    $('#dashboardSection').show();
    $('#employeeSection').hide();
    $('#navDashboard').addClass('active');
    $('#navEmployees').removeClass('active');
    refreshDashboard();
    if (typeof authService !== 'undefined' && authService.getCurrentUser) {
      $('#currentUserLabel').text(authService.getCurrentUser() ? authService.getCurrentUser().username : '');
    }
  }
 // Show employee section
  function showEmployeeSection() {
    $('#dashboardSection').hide();
    $('#employeeSection').show();
    $('#navDashboard').removeClass('active');
    $('#navEmployees').addClass('active');
    refreshEmployeeList();
    populateDeptFilter();
  }
    /* --Dashboard Data --*/

  function refreshDashboard() {
    if (typeof dashboardService === 'undefined' || typeof uiService === 'undefined') return;
    var summary = dashboardService.getSummary();
    var breakdown = dashboardService.getDepartmentBreakdown();
    var recent = dashboardService.getRecentEmployees(5);
    // Render UI
    uiService.renderDashboardCards(summary);
    uiService.renderDepartmentBreakdown(breakdown, summary.total);
    uiService.renderRecentEmployees(recent);
  }
    /* --Employee List --*/
  function refreshEmployeeList() {
    if (typeof employeeService === 'undefined' || typeof uiService === 'undefined') return;
     // Apply search + filters
    var filtered = employeeService.applyFilters(state.searchQuery, state.filterDept, state.filterStatus);
    // Apply sorting
    var sorted = employeeService.sortBy(filtered, state.sortField, state.sortDir);
    uiService.renderEmployeeTable(sorted);
  }
   /* --Populate Department Dropdown --*/

  function populateDeptFilter() {
    var all = employeeService ? employeeService.getAll() : [];
    var depts = {};
     // Collect unique departments
    all.forEach(function (e) { if (e.department) depts[e.department] = true; });
    var opts = '<option value="">All Departments</option>';
    Object.keys(depts).sort().forEach(function (d) { opts += '<option value="' + d + '">' + d + '</option>'; });
    $('#filterDepartment').html(opts);
  }
    /* --Sorting Logic */

  function applyFiltersAndSort() {
    var val = $('#sortSelect').val();
    if (val === 'name-asc') { state.sortField = 'name'; state.sortDir = 'asc'; }
    else if (val === 'name-desc') { state.sortField = 'name'; state.sortDir = 'desc'; }
    else if (val === 'salary-asc') { state.sortField = 'salary'; state.sortDir = 'asc'; }
    else if (val === 'salary-desc') { state.sortField = 'salary'; state.sortDir = 'desc'; }
    else if (val === 'date-asc') { state.sortField = 'date'; state.sortDir = 'asc'; }
    else if (val === 'date-desc') { state.sortField = 'date'; state.sortDir = 'desc'; }
    refreshEmployeeList();
  }


  if (typeof authService !== 'undefined' && authService.isLoggedIn && authService.isLoggedIn()) {
    showDashboardView();
  } else {
    showAuthView();
  }
//Switch to signup
  $('#linkSignup').on('click', function (e) {
    e.preventDefault();
    $('#loginView').hide();
    $('#signupView').show();
  });
   // Switch to login
$('#linkLogin').on('click', function (e) {
    e.preventDefault();
    $('#signupView').hide();
    $('#loginView').show();
  });
    // Login
  $('#loginForm').on('submit', function (e) {
    e.preventDefault();
    var username = $('#loginUsername').val();
    var password = $('#loginPassword').val();
    $('#loginUsernameError, #loginPasswordError, #loginGenericError').text('');
    
    var result = authService.login(username, password);
    if (result.success) {
      uiService.showToast('Login successful','success');
      showDashboardView();
    } else {
      $('#loginGenericError').text(result.message || 'Invalid credentials');
    }
  });
   // Signup
  $('#signupForm').on('submit', function (e) {
    e.preventDefault();
    var username = $('#signupUsername').val();
    var password = $('#signupPassword').val();
    var confirmPassword = $('#signupConfirmPassword').val();
    // Clear errors
    $('#signupUsernameError, #signupPasswordError, #signupConfirmPasswordError').text('');
    // Validate form
    var errors = validationService.validateAuthForm({ username: username, password: password, confirmPassword: confirmPassword }, 'signup');
    if (Object.keys(errors).length > 0) {
      if (errors.username) $('#signupUsernameError').text(errors.username);
      if (errors.password) $('#signupPasswordError').text(errors.password);
      if (errors.confirmPassword) $('#signupConfirmPasswordError').text(errors.confirmPassword);
      return;
    }
    // Create account
    var result = authService.signup(username, password, confirmPassword);
    if (result.success) {
      uiService.showToast('Signup successful', 'success');
      $('#signupView').hide();
      $('#loginView').show();
    } else {
      $('#signupUsernameError').text(result.message || 'Username already exists');
    }
  });

  // Logout
  $('#btnLogout').on('click', function () {
    authService.logout();
    uiService.showToast('Logged out', 'info');
    showAuthView();
  });

  $('#navDashboard').on('click', function (e) {
    e.preventDefault();
    showDashboardView();
  });

  $('#navEmployees').on('click', function (e) {
    e.preventDefault();
    showEmployeeSection();
  });
   // Open Add Employee modal
  $('#btnAddEmployee, #btnAddEmployeeSection').on('click', function () {
    uiService.showModal('add');
  });
    // Search and filter events
  $('#searchInput').on('input', function () {
    state.searchQuery = $(this).val();
    refreshEmployeeList();
  });

  $('#filterDepartment').on('change', function () {
    state.filterDept = $(this).val();
    refreshEmployeeList();
  });

  $('#filterStatus button').on('click', function () {
    state.filterStatus = $(this).data('status') || '';
    $('#filterStatus button').removeClass('active');
    $(this).addClass('active');
    refreshEmployeeList();
  });
  // Sorting
  $('#sortSelect').on('change', function () {
    applyFiltersAndSort();
  });
   /*-- Save Employee (Add / Edit) --*/
  $('#btnSaveEmployee').on('click', function () {
    var form = $('#employeeForm')[0];
    var fd = new FormData(form);
    // Collect form values
    var data = {
      firstName: fd.get('firstName'),
      lastName: fd.get('lastName'),
      email: fd.get('email'),
      phone: fd.get('phone'),
      department: fd.get('department'),
      designation: fd.get('designation'),
      salary: fd.get('salary'),
      joinDate: fd.get('joinDate'),
      status: fd.get('status')
    };
    var editId = $('#editEmployeeId').val();
    var isEdit = editId && editId !== '';

    var errors = validationService.validateEmployeeForm(data, isEdit ? parseInt(editId, 10) : undefined);
    if (Object.keys(errors).length > 0) {
      uiService.showInlineErrors(errors);
      return;
    }
    uiService.showInlineErrors({});

    if (isEdit) {
      var updated = employeeService.update(parseInt(editId, 10), data);
      if (updated) {
        uiService.showToast('Employee updated successfully', 'success');
        $('#addEditEmployeeModal').modal('hide');
        refreshEmployeeList();
        refreshDashboard();
      }
    } else {
      var added = employeeService.add(data);
      if (added) {
        uiService.showToast('Employee added successfully', 'success');
        $('#addEditEmployeeModal').modal('hide');
        refreshEmployeeList();
        refreshDashboard();
      }
    }
  });
// View employee
  $(document).on('click', '.btn-view', function () {
    var id = parseInt($(this).data('id'), 10);
    var emp = employeeService.getById(id);
    if (emp) uiService.showModal('view', emp);
  });
  // Edit employee
  $(document).on('click', '.btn-edit', function () {
    var id = parseInt($(this).data('id'), 10);
    var emp = employeeService.getById(id);
    if (emp) uiService.showModal('edit', emp);
  });

  // Delete employee
  $(document).on('click', '.btn-delete', function () {
    var id = parseInt($(this).data('id'), 10);
    var emp = employeeService.getById(id);
    if (emp) uiService.showModal('delete', emp);
  });
  /* --Confirm Delete --*/
  $('#btnConfirmDelete').on('click', function () {
    var id = $('#deleteConfirmModal').data('deleteId');
    if (id != null) {
      employeeService.remove(id);
      uiService.showToast('Employee deleted successfully', 'success');
      $('#deleteConfirmModal').modal('hide');
      refreshEmployeeList();
      refreshDashboard();
    }
  });
});
