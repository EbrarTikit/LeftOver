import React, { useState, useEffect } from "react";
import $ from "jquery";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import "./ForgotPasswordPage.css";
import { Link } from "react-router-dom";

const ForgotPasswordPage = () => {
  const [email, setEmail] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmNewPassword, setConfirmNewPassword] = useState("");
  const [message, setMessage] = useState("");
  const [error, setError] = useState("");
  const [step, setStep] = useState(1); // 1 for email input, 2 for password reset

  useEffect(() => {
    document.title = "FoodLeftover | Forgot Password";
  }, []);

  const handleEmailSubmit = (e) => {
    e.preventDefault();
    $.ajax({
      url: "https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/reset-password",
      type: "POST",
      contentType: "application/json",
      data: JSON.stringify({ email }),
      success: () => {
        setStep(2);
        setMessage("Check your email!");
      },
      error: () => {
        setError("Error sending email");
      },
    });
  };

  const handlePasswordSubmit = (e) => {
    e.preventDefault();
    if (newPassword !== confirmNewPassword) {
      setError("Passwords do not match");
      return;
    }
    $.ajax({
      url: "https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/reset-password",
      type: "POST",
      contentType: "application/json",
      data: JSON.stringify({ email, newPassword, confirmNewPassword }),
      success: () => {
        setMessage("Password updated successfully");
        setStep(3); // Final step or redirect to login
      },
      error: () => {
        setError("Error updating password");
      },
    });
  };

  return (
    <>
      <Header />
      <div className="forgot-password-page">
        <h1>Forgot Password</h1>
        {step === 1 && (
          <form onSubmit={handleEmailSubmit}>
            <div className="input-group">
              <input
                type="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                required
              />
            </div>
            <button type="submit">Send</button>
            {message && <p className="message">{message}</p>}
            {error && <p className="error">{error}</p>}
          </form>
        )}
        {step === 2 && (
          //         <form onSubmit={handlePasswordSubmit}>
          //         <div className="input-group">
          //           <label htmlFor="newPassword">New Password:</label>
          // //      <input
          //        type="password"
          //        placeholder="Password"
          //        value={password}
          //        onChange={(e) => setPassword(e.target.value)}
          //      />
          //      {errors.password && <div className="error">{errors.password}</div>}
          //    </div>
          //    <div className="confirm-password">
          //      <input
          //        type="password"
          //        placeholder="Confirm Password"
          //        value={confirmPassword}
          //        onChange={(e) => setConfirmPassword(e.target.value)}
          //      />
          //    </div>
          //  </div>
          <form onSubmit={handlePasswordSubmit}>
            <div className="input-group">
              <label htmlFor="newPassword">New Password:</label>
              <input
                type="password"
                id="newPassword"
                value={newPassword}
                onChange={(e) => setNewPassword(e.target.value)}
                required
              />
            </div>
            <div className="input-group">
              <label htmlFor="confirmNewPassword">Confirm Password:</label>
              <input
                type="password"
                id="confirmNewPassword"
                value={confirmNewPassword}
                onChange={(e) => setConfirmNewPassword(e.target.value)}
                required
              />
            </div>
            <button type="submit">Reset Password</button>
            {message && <p className="message">{message}</p>}
            {error && <p className="error">{error}</p>}
          </form>
        )}
        {step === 3 && (
          <div className="redirect-login">
            <p>
              Password updated successfully! You can now{" "}
              <div className="login-button">
                <Link to="/sign-in">Sign In</Link>
              </div>
            </p>
          </div>
        )}
      </div>
      <Footer />
    </>
  );
};

export default ForgotPasswordPage;
