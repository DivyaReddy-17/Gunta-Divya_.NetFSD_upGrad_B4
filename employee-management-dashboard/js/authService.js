(function (global) {
  //it stores all registred employees
  var admins = [];
  //stores current logged in user
  var currentUser = null;

  function init() {
    // Load default admin (if provided in data.js)
    if (typeof adminCredentialsSeed !== 'undefined' && adminCredentialsSeed) {
      admins = [{ username: adminCredentialsSeed.username, password: adminCredentialsSeed.password }];
    }
  }
  init();// Run initialization
//signup function
  function signup(username, password, confirmPassword) {
    // Validate input using validationService
    var errors = (typeof validationService !== 'undefined' && validationService.validateAuthForm)
      ? validationService.validateAuthForm({ username: username, password: password, confirmPassword: confirmPassword }, 'signup')
      : {};
      // If validation errors exist → return first error
    if (Object.keys(errors).length > 0) {
      return { success: false, message: Object.values(errors)[0] };
    }
    // Add new user if already exists
    if (admins.some(function (a) { return a.username === username; })) {
      return { success: false, message: 'Username already exists' };
    }
    //add new user to admins array
    admins.push({ username: username, password: password });
    return { success: true };
  }

  //Login function
  function login(username, password) {
     // Validate input
    var errors = (typeof validationService !== 'undefined' && validationService.validateAuthForm)
      ? validationService.validateAuthForm({ username: username, password: password }, 'login')
      : {};
    if (Object.keys(errors).length > 0) {
      return { success: false, message: Object.values(errors)[0] };
    }
    // Find matching user
    var user = admins.find(function (a) { return a.username === username && a.password === password; });
     // If not found → invalid credentials
    if (!user) {
      return { success: false, message: 'Invalid credentials' };
    }
     // Store logged-in user (session)
    currentUser = { username: user.username };
    return { success: true };
  }
   /* --LOGOUT FUNCTION --*/

  function logout() {
    currentUser = null;
  }

    /* --CHECK LOGIN STATUS --*/
  function isLoggedIn() {
    return currentUser != null;
  }

    /* --GET CURRENT USER --*/
  function getCurrentUser() {
    return currentUser;
  }
  // Attach functions to global object so app.js can use them
  global.authService = {
    signup: signup,
    login: login,
    logout: logout,
    isLoggedIn: isLoggedIn,
    getCurrentUser: getCurrentUser
  };
})(typeof window !== 'undefined' ? window : global);
