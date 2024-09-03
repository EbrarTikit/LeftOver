import './App.css';
import BusinessRegisterPage from './Components/BusinessRegisterPage/BusinessRegisterPage';
import BusinessMainPage from './Components/BusinessMainPage/BusinessMainPage';
import ConsumerPage from './Components/ConsumerPage/ConsumerPage';
import SignIn from './Components/LoginPage/LoginPage';
import LandingPage from './Components/LandingPage/LandingPage';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import BusinessDatabasePage from './Components/BusinessDatabasePage/BusinessDatabasePage';
import BusinessEditInventoryPage from './Components/BusinessEditInventoryPage/BusinessEditInventoryPage';
import ReservationsPage from './Components/ReservationsPage/ReservationsPage';
import BusinessDeleteAccPage from './Components/BusinessDeleteAccPage/BusinessDeleteAccPage';
import ForgotPasswordPage from './Components/ForgotPasswordPage/ForgotPasswordPage';
import BusinessUpdateLocationPage from './Components/UpdateLocationPage/UpdateLocationPage';
import BusinessDeleteInventoryPage from './Components/BusinessDeleteInventoryPage/BusinessDeleteInventoryPage';
import BusinessAddInventoryPage from './Components/BusinessAddInventoryPage/BusinessAddInventoryPage';
import { AuthProvider } from './AuthContext';
import PrivateRoute from './PrivateRoute';
import PublicRoute from './PublicRoute';

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<LandingPage />} />
          <Route path='/sign-up' element={<BusinessRegisterPage />} />
          <Route path='/business' element={<BusinessMainPage />} />
          <Route path='/consumer' element={<ConsumerPage />} />
          <Route path='/sign-in' element={<PublicRoute element={SignIn} />} />
          <Route path='/database' element={<PrivateRoute element={<BusinessDatabasePage />} />} />
          <Route path='/edit-inventory' element={<PrivateRoute element={<BusinessEditInventoryPage />} />} />
          <Route path='/reservations' element={<PrivateRoute element={<ReservationsPage />} />} />
          <Route path='/delete-account' element={<PrivateRoute element={<BusinessDeleteAccPage />} />} />
          <Route path='/forgot-password' element={<PublicRoute element={ForgotPasswordPage} />} />
          <Route path='/update-information' element={<PrivateRoute element={<BusinessUpdateLocationPage />} />} />
          <Route path='/delete-inventory' element={<PrivateRoute element={<BusinessDeleteInventoryPage />} />} />
          <Route path='/add-inventory' element={<PrivateRoute element={<BusinessAddInventoryPage />} />} />



        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
