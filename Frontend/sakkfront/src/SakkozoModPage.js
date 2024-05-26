import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

export function SakkozoModPage(props) {
    const params = useParams();
    const id = params.sakkozoId;
    const navigate = useNavigate();
    const [sakkozo,setSakkozo] = useState([]);
    const[modname,setModname] = useState('');
    const[modszul,setModszul] = useState('');
    const[modbajnoksagok,setModbajnoksagok] = useState('');
    const[modprofileurl,setModprofileurl] = useState('');
    const[modimageurl,setModimageurl] = useState('');

    useEffect(() => {
        (async () => {

            try {
                const res = await fetch(`http://localhost:3001/chess/${id}`)
                const sakkozo = await res.json();
                setSakkozo(sakkozo);
                setModname(sakkozo.name);
                console.log(modname);
                setModszul(sakkozo.birth_date);
                console.log(modszul);
                setModbajnoksagok(sakkozo.world_ch_won);
                console.log(modbajnoksagok);
                setModprofileurl(sakkozo.profile_url);
                console.log(modprofileurl);
                setModimageurl(sakkozo.image_url);
                console.log(modimageurl);
               
            }
            catch(error) {
                console.log(error);
            }
        })
        (); 
    }, [id,modname,modszul,modbajnoksagok,modprofileurl,modimageurl]);
   
    const modName = event => {
        setModname(event.target.value);
    }
    const modSzul = event => {
        setModszul(event.target.value);
    }
    const modBajnoksagok = event => {
        setModbajnoksagok(event.target.value);
    }
    const modProfileurl = event => {
        setModprofileurl(event.target.value);
    }
    const modImageurl = event => {
        setModimageurl(event.target.value);
    }

    return (
        <div className="p-5 content bg-whitesmoke text-center">
            <h2>Sakkozó módosítása</h2>
            <form
            onSubmit={(event) => {
                event.persist();
                event.preventDefault();
                fetch(`http://localhost:3001/chess/${id}`, {
                    method: "PUT",
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        id: event.target.elements.id.value,
                        name: event.target.elements.name.value,
                        birth_date: event.target.elements.birth_date.value,
                        world_ch_won: event.target.elements.world_ch_won.value,
                        profile_url: event.target.elements.profile_url.value,
                        image_url: event.target.elements.image_url.value,
                    }),
                })
                .then(() => {
                    navigate("/");
                })
                .catch(console.log);
            }}>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Sakkozó ID:</label>
                    <div className="col-sm-9">
                        <input type="text" name="id" className="form-control" value={sakkozo.id}/>
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Sakkozó név:</label>
                    <div className="col-sm-9">
                        <input type="text" name="name" className="form-control" defaultValue={sakkozo.name} onChange={modName}/>
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Születési idő:</label>
                    <div className="col-sm-9">
                        <input type="text" name="birth_date" className="form-control" defaultValue={sakkozo.birth_date} onChange={modSzul}/>
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Megnyert bajnokságok:</label>
                    <div className="col-sm-9">
                        <input type="number" name="world_ch_won" className="form-control" defaultValue={sakkozo.world_ch_won} onChange={modBajnoksagok}/>
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Profil URL-je:</label>
                    <div className="col-sm-9">
                        <input type="text" name="profile_url" className="form-control" defaultValue={sakkozo.profile_url} onChange={modProfileurl}/>
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Kép URL-je:</label>
                    <div className="col-sm-9">
                        <input type="text" name="image_url" className="form-control" defaultValue={sakkozo.image_url} onChange={modImageurl}/>
                    <img src={sakkozo.image_url} height="200px" alt={sakkozo.name}/>
                    </div>
                </div>
                <button type="submit" className="btn btn-success">Küldés</button>
            </form>
        </div>
    );
    }
export default SakkozoModPage;