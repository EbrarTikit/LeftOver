
import React, { useState } from 'react';
import './ConsumerPage.css'; 
import Header from '../Header/Header';
import Footer from '../Footer/Footer';

import Handshake from '../../Assets/images/handshake.png';
import Heart from '../../Assets/images/heart.png';
import LoginScreen from '../../Assets/images/LoginScreen.png';
import { useEffect } from 'react';
const ConsumerPage = () => {

  
  useEffect(() => {
    document.title = 'FoodLeftover | Consumer Page';
  }, []);

  return (
    <>
      <Header/>

        <div className='how-it-works'>
            <div className='phone'>
                <img src={LoginScreen} alt='Login Screen' />
            </div>
            <div className='phone-right'>
                <h1>HOW IT WORKS</h1>
                <p>Take your food to go and enjoy. You’ve just saved a meal from going to waste and done something good for the planet!</p>
                <button> Download on Play Store <i class="fa-brands fa-google-play fa-2xl"></i></button>
            </div>
        </div>
        <div className="statistics">
            <div className="users">
                <img src={Heart} alt="Heart" />
                <span className='amount'>50K</span>
                <span>Users of the Leftover Saver App</span>
            </div>
            <div className="active">
                <img src={Handshake} alt="Handshake" />
                <span className='amount'>10K</span>
                <span>Active Businesses on the Platform</span>
            </div>
        </div>
      <Footer />
    </>
  )
      
  ;
};

export default ConsumerPage;
