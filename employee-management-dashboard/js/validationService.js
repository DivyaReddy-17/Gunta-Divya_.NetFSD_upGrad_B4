//client-side form validation logic for auth forms and employee forms.
(function (global) {
   // Regular expression to validate email format
  var EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  function validateAuthForm(formData, formType) {
    var errors = {};
    // Signup validation
    if (formType === 'signup') {
      // Username validation
      if (!formData.username || String(formData.username).trim() === '') {
        errors.username = 'Username is required';
      }
      // Password validation
      if (!formData.password || String(formData.password).trim() === '') {
        errors.password = 'Password is required';
      } else if (formData.password.length < 6) {
        errors.password = 'Password must be at least 6 characters';
      }
      // Confirm password validation
      if (!formData.confirmPassword || String(formData.confirmPassword).trim() === '') {
        errors.confirmPassword = 'Confirm Password is required';
      } else if (formData.password !== formData.confirmPassword) {
        errors.confirmPassword = 'Passwords do not match';
      }
    } else {
       // Login validation.
      if (!formData.username || String(formData.username).trim() === '') {
        errors.username = 'Username is required';
      }
      if (!formData.password || String(formData.password).trim() === '') {
        errors.password = 'Password is required';
      }
    }
    return errors;
  }
  //validate employee form.
  function validateEmployeeForm(formData, excludeId) {
    var errors = {};
     // First name validation
    if (!formData.firstName || String(formData.firstName).trim() === '') {
      errors.firstName = 'First name is required';
    }
    // Last name validation
    if (!formData.lastName || String(formData.lastName).trim() === '') {
      errors.lastName = 'Last name is required';
    }
    // Email validation
    if (!formData.email || String(formData.email).trim() === '') {
      errors.email = 'Email is required';
    } else if (!EMAIL_REGEX.test(formData.email)) {
      errors.email = 'Invalid email format';
    }
    // Phone validation
    if (!formData.phone || String(formData.phone).trim() === '') {
      errors.phone = 'Phone is required';
    } else {
      var digits = formData.phone.replace(/\D/g, '');
      if (digits.length !== 10) {
        errors.phone = 'Phone must be exactly 10 digits';
      }
    }
    // Department validation
    if (!formData.department || String(formData.department).trim() === '') {
      errors.department = 'Department is required';
    }
    // Designation validation
    if (!formData.designation || String(formData.designation).trim() === '') {
      errors.designation = 'Designation is required';
    }
    // Salary validation
    if (formData.salary === '' || formData.salary == null) {
      errors.salary = 'Salary is required';
    } else {
      var sal = Number(formData.salary);
      if (isNaN(sal) || sal <= 0) {
        errors.salary = 'Salary must be a positive number';
      }
    }
     // Join date validation
    if (!formData.joinDate || String(formData.joinDate).trim() === '') {
      errors.joinDate = 'Join date is required';
    }
    // Status validation
    if (!formData.status || String(formData.status).trim() === '') {
      errors.status = 'Status is required';
    }
    /*Duplicate email validation
     Only runs if email format is valid
     Uses employeeService to check uniqueness
     */
    if (!errors.email && typeof employeeService !== 'undefined' && employeeService.hasEmail) {
      if (employeeService.hasEmail(formData.email, excludeId)) {
        errors.email = 'Email already exists';
      }
    }
    return errors;
  }
  // Expose validation functions globally.
  global.validationService = {
    validateAuthForm: validateAuthForm,
    validateEmployeeForm: validateEmployeeForm
  };
})(typeof window !== 'undefined' ? window : global);
