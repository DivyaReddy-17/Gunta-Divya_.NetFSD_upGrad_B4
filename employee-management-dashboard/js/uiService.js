
/*Handles DOM manipulation (tables, cards, lists)
 Renders employee data to UI
 Controls modals, toasts, and form handling
 */
(function (global) {
  // Reference to jQuery (fallback safety)
  var $ = typeof jQuery !== 'undefined' ? jQuery : null;

  function formatSalary(num) {
    return Number(num).toLocaleString('en-IN');
  }
  //Get CSS class for department badge
  function getDeptBadgeClass(dept) {
    // Fallback if department not found
    var map = { Engineering: 'badge-dept-engineering', Marketing: 'badge-dept-marketing', HR: 'badge-dept-hr', Finance: 'badge-dept-finance', Operations: 'badge-dept-operations' };
    var specificclass = map[dept] || 'badge-secondary';
    return map[dept] || 'bg-secondary';
  }
  //Render employee table
  function renderEmployeeTable(employees) {
    if (!$) return;
    var tbody = $('#employeeTableBody');
    if (!tbody.length) return;
    if (!employees || employees.length === 0) {
      tbody.html('<tr><td colspan="9" class="text-center text-muted py-4">No employees found</td></tr>');
      return;
    }
    var html = '';
    employees.forEach(function (emp, i) {
      // Status badge styling
      var statusClass = emp.status === 'Active' ? 'badge-status-active' : 'badge-status-inactive';
       // Department badge styling
      var deptClass = getDeptBadgeClass(emp.department);
      var rowClass = i % 2 === 0 ? 'table-light' : '';
      html += '<tr class="' + rowClass + '" data-id="' + emp.id + '">' +
        '<td>' + emp.id + '</td>' +
        '<td>' + (emp.firstName || '') + ' ' + (emp.lastName || '') + '</td>' +
        '<td>' + (emp.email || '') + '</td>' +
        '<td><span class="badge ' + deptClass + '">' + (emp.department || '') + '</span></td>' +
        '<td>' + (emp.designation || '') + '</td>' +
        '<td>₹' + formatSalary(emp.salary) + '</td>' +
        '<td>' + (emp.joinDate || '') + '</td>' +
        '<td><span class="badge ' + statusClass + '">' + (emp.status || '') + '</span></td>' +
        //action buttons (view, edit, delete)
        '<td class="text-end">' +
        '<button class="btn btn-sm btn-outline-primary btn-view" data-id="' + emp.id + '"><i class="bi bi-eye"></i></button> ' +
        '<button class="btn btn-sm btn-outline-warning btn-edit" data-id="' + emp.id + '"><i class="bi bi-pencil"></i></button> ' +
        '<button class="btn btn-sm btn-outline-danger btn-delete" data-id="' + emp.id + '"><i class="bi bi-trash"></i></button>' +
        '</td></tr>';
    });
    tbody.html(html);
  }
  //Render dashboard summary cards
  function renderDashboardCards(summary) {
    if (!$) return;
    var cards = $('#summaryCards');
    if (!cards.length) return;
    //total employees card, active employees card, inactive employees card, department count card.
    var html ='<div class="col-12 col-sm-6 col-lg-3">'+ '<div class="card border-0 border-top border-4 border-primary shadow-sm dashboard-card h-100">'+ '<div class="card-body d-flex align-items-center">'+'<div class="bg-primary bg-opacity-10 rounded p-2 me-3">'+'<i class="bi bi-people-fill text-primary fs-4">'+'</i></div><div><h3 class="fw-bold mb-0">' + (summary.total || 0) + '</h3>'+'<small class="text-muted fw-bold">TOTAL EMPLOYEES</small>'+'</div>'+'</div>'+'</div>'+'</div>' +
      '<div class="col-12 col-sm-6 col-lg-3">'+ '<div class="card border-0 border-top border-4 border-success shadow-sm dashboard-card h-100">'+ '<div class="card-body d-flex align-items-center">'+'<div class="bg-success bg-opacity-10 rounded p-2 me-3">'+'<i class="bi bi-person-check text-success fs-4">'+'</i>'+'</div>'+'<div>'+'<h3 class="fw-bold mb-0" text-success fs-4">' + (summary.active || 0) + '</h3><small class="text-muted fw-bold">ACTIVE</small>'+'</div>'+'</div>'+'</div>'+'</div>' +
      '<div class="col-12 col-sm-6 col-lg-3"><div class="card border-0 border-top border-4 border-danger shadow-sm dashboard-card h-100"><div class="card-body d-flex align-items-center"><div class="bg-danger bg-opacity-10 rounded p-2 me-3"><i class="bi bi-person-x text-danger fs-4"></i></div><div><h3 class="fw-bold mb-0">' + (summary.inactive || 0) + '</h3><small class="text-muted fw-bold">INACTIVE</small></div></div></div></div>' +
      '<div class="col-12 col-sm-6 col-lg-3"><div class="card border-0 border-top border-4 border-warning shadow-sm dashboard-card h-100"><div class="card-body d-flex align-items-center"><div class="bg-warning bg-opacity-10 rounded p-2 me-3"><i class="bi bi-diagram-3 text-warning fs-4"></i></div><div><h3 class="fw-bold mb-0">' + (summary.departments || 0) + '</h3><small class="text-muted fw-bold">DEPARTMENTS</small></div></div></div></div>';
    cards.html(html);
    
  }
  function renderDepartmentBreakdown(data, total) {
    if (!$) return;
    var el = $('#deptBreakdownBody');
    if (!el.length) return;
    var html = '';
    var keys = Object.keys(data || {}).sort();
    keys.forEach(function (dept) {
      var count = data[dept] || 0;
      var pct = total > 0 ? Math.round((count / total) * 100) : 0;
      html += '<tr><td>' + dept + '</td><td>' + count + '</td><td><div class="progress" style="height:8px"><div class="progress-bar bg-primary" style="width:' + pct + '%"></div></div></td><td class="text-end">' + pct + '%</td></tr>';
    });
    el.html(html || '<tr><td colspan="4" class="text-muted">No data</td></tr>');
  }
  //render recent employee list.
  function renderRecentEmployees(employees) {
    if (!$) return;
    var list = $('#recentEmployeesList');
    if (!list.length) return;
    var html = '';
    (employees || []).forEach(function (emp) {
      var statusClass = emp.status === 'Active' ? 'badge-status-active' : 'badge-status-inactive';
      var deptClass = getDeptBadgeClass(emp.department);
      html += 
      '<li class="list-group-item d-flex justify-content-between align-items-center">' +
        '<div><div class="fw-semibold">' + (emp.firstName || '') + ' ' + (emp.lastName || '') + '</div><small class="text-muted">' + (emp.designation || '') + '</small></div>' +
        '<span><span class="badge ' + deptClass + ' me-1">' + (emp.department || '') + '</span><span class="badge ' + statusClass + '">' + (emp.status || '') + '</span></span>' +
        '</li>';
    });
    list.html(html || '<li class="list-group-item text-muted">No recent employees</li>');
  }
  //show modal for add/edit/view/delete actions
  function showModal(type, data) {
    if (!$) return;
    if (type === 'add') {
      clearForm();
      $('#addEditModalTitle').text('Add Employee');
      $('#btnSaveEmployee').text('Save Employee');
      $('#editEmployeeId').val('');
      $('#addEditEmployeeModal').modal('show');
    } else if (type === 'edit' && data) {
      populateForm(data);
      $('#addEditModalTitle').text('Edit Employee');
      $('#btnSaveEmployee').text('Update Employee');
      $('#editEmployeeId').val(data.id);
      $('#addEditEmployeeModal').modal('show');
    } else if (type === 'view' && data) {
      var body = $('#viewEmployeeBody');
      body.html('<p><b>ID:</b> ' + data.id + '</p><p><b>Name:</b> ' + (data.firstName || '') + ' ' + (data.lastName || '') + '</p><p><b>Email:</b> ' + (data.email || '') + '</p><p><b>Phone:</b> ' + (data.phone || '') + '</p><p><b>Department:</b> ' + (data.department || '') + '</p><p><b>Designation:</b> ' + (data.designation || '') + '</p><p><b>Salary:</b> ₹' + formatSalary(data.salary) + '</p><p><b>Join Date:</b> ' + (data.joinDate || '') + '</p><p><b>Status:</b> ' + (data.status || '') + '</p>');
      $('#viewEmployeeModal').modal('show');
    } else if (type === 'delete' && data) {
      $('#deleteEmployeeName').text((data.firstName || '') + ' ' + (data.lastName || ''));
      $('#deleteConfirmModal').data('deleteId', data.id);
      $('#deleteConfirmModal').modal('show');
    }
  }
  //populate form fields with employee data.
  function populateForm(employee) {
    if (!$ || !employee) return;
    $('#employeeForm [name="firstName"]').val(employee.firstName || '');
    $('#employeeForm [name="lastName"]').val(employee.lastName || '');
    $('#employeeForm [name="email"]').val(employee.email || '');
    $('#employeeForm [name="phone"]').val(employee.phone || '');
    $('#employeeForm [name="department"]').val(employee.department || '');
    $('#employeeForm [name="designation"]').val(employee.designation || '');
    $('#employeeForm [name="salary"]').val(employee.salary || '');
    $('#employeeForm [name="joinDate"]').val(employee.joinDate || '');
    $('#employeeForm [name="status"]').val(employee.status || '');
  }
  //Show toast notification
  function showToast(message, type) {
    if (!$) return;
    type = type || 'success';
    var bg = type === 'success' ? 'bg-success' : type === 'error' ? 'bg-danger' : 'bg-info';
    var id = 'toast-' + Date.now();
    var html = '<div class="toast align-items-center text-white ' + bg + ' border-0" id="' + id + '" role="alert"><div class="d-flex"><div class="toast-body">' + (message || '') + '</div><button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button></div></div>';
    $('#toastContainer').append(html);
    var toastEl = document.getElementById(id);
    if (toastEl) {
      var toast = new bootstrap.Toast(toastEl, { delay: 3000 });
      toast.show();
      toastEl.addEventListener('hidden.bs.toast', function () { $(toastEl).remove(); });
    }
  }
  //Show inline form validation errors
  function showInlineErrors(errors) {
    if (!$) return;
    $('#employeeForm [data-field]').each(function () {
      var field = $(this).attr('data-field');
      var msg = (errors || {})[field] || '';
      $(this).text(msg);
    });
  }
  // Reset form and clear errors
  function clearForm() {
    if (!$) return;
    $('#employeeForm')[0].reset();
    $('#editEmployeeId').val('');
    showInlineErrors({});
  }
  //Expose globally.
  global.uiService = {
    renderEmployeeTable: renderEmployeeTable,
    renderDashboardCards: renderDashboardCards,
    renderDepartmentBreakdown: renderDepartmentBreakdown,
    renderRecentEmployees: renderRecentEmployees,
    showModal: showModal,
    populateForm: populateForm,
    showToast: showToast,
    showInlineErrors: showInlineErrors,
    clearForm: clearForm
  };
})(typeof window !== 'undefined' ? window : global);
