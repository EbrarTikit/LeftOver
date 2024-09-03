import React from "react";
import "./Footer.css";

const Footer = () => {
  return (
    <footer>
      <div className="middle">
        <div className="links">
          <div className="pages">
            <span>Blog</span>
            <span>Careers</span>
            <span>Press</span>
            <span>Support</span>
          </div>
          <div className="policies">
            <span>Privacy Policy</span>
            <span>Cookie Policy</span>
            <span>Terms & Conditions</span>
            <span>Promotion and Referral Terms</span>
          </div>
        </div>
        <div className="socials">
          <i
            className="fa-brands fa-youtube fa-2xl"
            style={{ color: "#0097B2" }}
          ></i>
          <i
            className="fa-brands fa-linkedin fa-2xl"
            style={{ color: "#0097B2" }}
          ></i>
          <i
            className="fa-brands fa-instagram fa-2xl"
            style={{ color: "#0097B2" }}
          ></i>
          <i
            className="fa-brands fa-twitter fa-2xl"
            style={{ color: "#0097B2" }}
          ></i>
        </div>
      </div>
      <div className="bottom">
        <div className="mediabuttons">
          <button>
            Download on Play Store
            <i className="fa-brands fa-google-play fa-2xl"></i>
          </button>
          <button>
            Download on App Store <i className="fa-brands fa-apple fa-2xl"></i>
          </button>
        </div>
        <span>Copyrights 2024 All Rights Reserved</span>
      </div>
    </footer>
  );
};

export default Footer;
