import React from 'react';
import Logo from '../../Assets/images/AppLogo.jpg';
import './BasicHeader.css'; // import your CSS file


const BasicHeader = () => {
    return (
            <div className="basicheader">
               <img className="logo" src={Logo} alt="Logo" />
            </div>
    );
};
export default BasicHeader;