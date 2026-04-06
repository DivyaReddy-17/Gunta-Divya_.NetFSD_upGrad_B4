//unit tests for authentication module.
beforeAll(function () {
  global.adminCredentialsSeed = { username: 'admin', password: 'admin123' };
  /*Mock validationService
   Simulates validation logic for auth forms
   Keeps tests independent from real validationService
   */
  global.validationService = {
    validateAuthForm: function (fd, type) {
      var err = {};
      //username and password required for both login and signup
      if (!fd.username || !fd.username.trim()) err.username = 'Username is required';
      if (!fd.password || !fd.password.trim()) err.password = 'Password is required';
      if (type === 'signup') {
        if (fd.password && fd.password.length < 6) err.password = 'Password must be at least 6 characters';
        if (!fd.confirmPassword || fd.confirmPassword !== fd.password) err.confirmPassword = 'Passwords do not match';
      }
      return err;
    }
  };
});
//reset before each test.
beforeEach(function () {
  // Reset admin credentials before every test.
  global.adminCredentialsSeed = { username: 'admin', password: 'admin123' };
});

describe('authService', function () {
  // Load authService module once before tests
  beforeAll(function () {
    require('../js/authService.js');
  });
  //Prevent duplicate username signup
  test('signup rejects duplicate username', function () {
    // First signup should succeed
    var r1 = authService.signup('newuser', 'password123', 'password123');
    expect(r1.success).toBe(true);
    // Second signup with same username should fail
    var r2 = authService.signup('newuser', 'otherpass123', 'otherpass123');
    // Error message should indicate duplication
    expect(r2.success).toBe(false);
    expect(r2.message).toContain('already exists');
  });
  // Reject short passwords during signup
  test('signup rejects short password', function () {
    var result = authService.signup('user1', '12345', '12345');
    expect(result.success).toBe(false);
  });
  //Successful login with correct credentials.
  test('login succeeds with correct credentials', function () {
    var result = authService.login('admin', 'admin123');
    expect(result.success).toBe(true);
    expect(authService.isLoggedIn()).toBe(true);
  });
  //Login failure with incorrect password
  test('login fails with wrong credentials', function () {
    var result = authService.login('admin', 'wrongpass');
    // Error message should indicate invalid credentials
    expect(result.success).toBe(false);
    expect(result.message).toContain('Invalid');
  });
  //Logout clears session state
  test('logout clears session', function () {
    //Login first
    authService.login('admin', 'admin123');
    authService.logout();
    // Session should be cleared
    expect(authService.isLoggedIn()).toBe(false);
  });
});
