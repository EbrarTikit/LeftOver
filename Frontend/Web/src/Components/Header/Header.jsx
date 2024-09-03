import React, { useContext } from "react";
import Logo from "../../Assets/images/AppLogo.jpg";
import { AuthContext } from "../../AuthContext";
import { Link } from "react-router-dom";

import Profile_Icon from "../../Assets/images/profile_icon.png";

import "./Header.css";

const Header = () => {
  const { isAuthenticated, logout } = useContext(AuthContext);

  return (
    <div className="header">
      <Link className="logo" to="/">
        <img src={Logo} alt="Logo" />
      </Link>

      <div className="exceptLogo">
        <div className="leftdiv">
          <Link className="consumer" to="/consumer">
            <span>Consumer</span>
          </Link>
          <Link className="business" to="/business">
            <span>Business</span>
          </Link>
        </div>

        {/* authentication part begins */}

        {isAuthenticated ? (
          <div className="rightdiv">
            <div>
              <Link className="profileIcon" to="/database">
                <img
                  style={{ width: "3.5rem" }}
                  src={Profile_Icon}
                  alt="Profile Icon"
                />
              </Link>
            </div>
            <div>
              <button onClick={logout}>Logout</button>
            </div>
          </div>
        ) : (
          <>
            <div className="rightdiv">
              <Link to="/sign-in">
                <button>Sign In</button>
              </Link>
              <Link to="/sign-up">
                <button>Sign Up</button>
              </Link>
            </div>
          </>
        )}

        {/* authentication part ends */}
      </div>
    </div>
  );
};

export default Header;
