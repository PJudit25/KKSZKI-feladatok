import React, { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';

export function SakkozoListPage() {

    const[sakkozos,setSakkozos] = useState([]);
    const[isFetchPending, setFetchPending] = useState(false);
    
    useEffect(() => {
        setFetchPending(true);
        fetch("http://localhost:3001/chess")
            .then((res) => res.json())
            .then((sakkozok) => setSakkozos(sakkozok))
            .catch(console.log)
            .finally(() => {
                setFetchPending(false);
            });
    }, []);
    return (
        <div className="p-5 m-auto text-center content bg-ivory">
            {isFetchPending ? (
                <div className="spinner-border"></div>
            ) : (
                <div>
                    <h2>Sakkozók</h2>
                    {sakkozos.map((sakkozo) => (

                        <div className="card col-sm-3 d-inline-block m-1 p-2">
                            <p className="text-dark">Sakkozó neve: {sakkozo.name}</p>
                            <p className="text-dark">Születési idő:{sakkozo.birth_date}</p>
                            <p className="text-dark">Megnyert bajnokságok: {sakkozo.world_ch_won}</p>
                            <p className="text-dark">Profil link: <a href={sakkozo.profile_url} target='_blank'>{sakkozo.profile_url}</a></p>
                            <div className="card-body">
                                <NavLink key={sakkozo.id} to={"/sakkozo/" + sakkozo.id}>
                                    <img alt={sakkozo.name}
                                        className="img-fluid"
                                        style={{ maxHeight: 200 }}
                                        src={sakkozo.image_url ? sakkozo.image_url :
                                            "https://via.placeholder.com/400x800"} /></NavLink>
                                <br />
                                <NavLink key="y" to={"/mod-sakkozo/" + sakkozo.id}>
                                    <i className="bi bi-pencil"></i></NavLink> &nbsp;&nbsp;
                                    <NavLink key="x" to={"/del-sakkozo/" + sakkozo.id}><i className="bi bi-trash3"></i></NavLink>
                            </div>
                        </div>


                    ))}
                </div>
            )}
        </div>
    );
}
export default SakkozoListPage;