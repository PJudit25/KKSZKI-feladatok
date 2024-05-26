import { BrowserRouter as Router, NavLink, Routes, Route } from "react-router-dom";
import { SakkozoListPage } from "./SakkozoListPage";
import { SakkozoSinglePage } from "./SakkozoSinglePage";
import { SakkozoCreatePage } from "./SakkozoCreatePage";
import { SakkozoModPage } from "./SakkozoModPage";
import { SakkozoDelPage } from "./SakkozoDelPage";
import './App.css';

function App() {
  return (
    <Router>
      <nav className="navbar navbar-expand-sm navbar-dark bg-dark">
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink to={'/'} className={({isActive}) => "nav-link" + (isActive ? "active" : "")}>
                <span className="nav-link">Sakkozók</span>
              </NavLink>
              </li>
              <li className="nav-item">
              <NavLink to={'/uj-sakkozo'} className={({isActive}) => "nav-link" + (isActive ? "active" : "")}>
                <span className="nav-link">Új sakkozó</span>
              </NavLink>
              </li>
          </ul>
        </div>
      </nav>
      <Routes>
        <Route path="/" exact element={<SakkozoListPage />} />
        <Route path="/sakkozo/:sakkozoId" exact element={<SakkozoSinglePage />} />
        <Route path="/uj-sakkozo" exact element={<SakkozoCreatePage />} />
        <Route path="/mod-sakkozo/:sakkozoId" exact element={<SakkozoModPage />} />
        <Route path="/del-sakkozo/:sakkozoId" exact element={<SakkozoDelPage />} />
      </Routes>
    </Router>
  );
}

export default App;