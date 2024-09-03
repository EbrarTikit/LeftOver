
import React, { useState } from 'react';
import './LandingPage.css'; 
import Header from '../Header/Header';
import Footer from '../Footer/Footer';
import Groceries from '../../Assets/images/Groceries.jpg';
import Delivery from '../../Assets/images/Delivery.jpg';
import Saveameal from '../../Assets/images/Saveameal.jpg';
import { useEffect } from 'react';

const LandingPage = () => {
 

  useEffect(() => {
    document.title = 'FoodLeftover';
  }, []);

  return (
    <>
      <Header/>
      <div className='content'>
        <div className='first-row'>
          <img src={Delivery} alt='Delivery' />
          <div className='first-row-right'>
            <h1>What are we doing?</h1>
            <p>At Food Leftover Saver, our mission is to combat food waste by connecting people with surplus food from local businesses at reduced prices. We partner with restaurants, cafes, and grocery stores to offer you fresh, delicious meals and ingredients that would otherwise go to waste. Together, we can save food, save money, and make a positive impact on our planet.</p>
          </div>
        </div>
        <div className='second-row'>
          <img src={Groceries} alt='Groceries' />
          <div className='second-row-left'>
            <h1>Our Mission and Vision</h1>
            <p>Our mission is to tackle food waste by offering a platform that provides access to discounted, high-quality surplus food from local businesses. 
Our vision is a sustainable future where food waste is a thing of the past, and everyone benefits from the efficient use of surplus food. By building a community of mindful consumers and supportive businesses, we strive to make this vision a reality.</p>
          </div>
        </div>
        <div className='third-row'>
          <img src={Saveameal} alt='Saveameal' />
          <div className='third-row-right'>
            <h1>How it works?</h1>
            <p>The Leftover Saver Application is designed to reduce food waste and provide customers with discounted products from local businesses. Businesses sign up, set up their profiles, and list leftover products by providing details such as product name, description, original price, discounted price, available quantity, and pick-up times. They can manage inventory and monitor sales and customer engagement through a dashboard while receiving notifications for reservations and pick-up times. Customers download the app for free, sign up, and set their location preferences to find nearby businesses offering discounts. They browse detailed product listings, make reservations, and receive confirmation notifications, then go to the business location within the specified time to pick up their reserved products.</p>
          </div>
        </div>
      </div>

      


      <Footer />
    </>
  )
      
  ;
};

export default LandingPage;
