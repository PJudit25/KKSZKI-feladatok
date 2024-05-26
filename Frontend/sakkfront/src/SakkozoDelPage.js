import React, { useState, useEffect } from 'react';
import { useParams, useNavigate, NavLink } from 'react-router-dom';

export function SakkozoDelPage(props) {
    const params = useParams();
    const id = params.sakkozoId;
    const navigate = useNavigate();
    const[sakkozo,setSakkozo] = useState([]);
    const[isPending, setPending] = useState(false);
    useEffect(() => {
        setPending(true);
        (async () => {
            try {
        const res= await fetch(`http://localhost:3001/chess/${id}`)
            const sakkozo = await res.json();
            setSakkozo(sakkozo);
        }
        catch(error) {
            console.log(error);
        }
        finally {
            setPending(false);
        }
    })
    ();
 }, [id]);
 return (
    <div className="p-5 m-auto text-center content bg-lavender">
        {isPending || !sakkozo.id ? (
            <div className="spinner-border"></div>
        ) : (
                        <div className="card p-3">
                            <div className="card-body">
                            <h5 className="card-title">Törlendő elem: {sakkozo.name}</h5>
                            <p className="card-text">Születési idő: {sakkozo.birth_date}</p>
                            <p className="card-text">Megnyert bajnokságok: {sakkozo.world_ch_won}</p>
                            <p className="card-text">Profil link: <a href={sakkozo.profile_url} target='_blank'>{sakkozo.profile_url}</a></p>
                                <img alt={sakkozo.name}
                                className="img-fluid rounded"
                                style={{maxHeight: "500px"}}
                                src={sakkozo.image_url ? sakkozo.image_url : 
                                "https://via.placeholder.com/400x800"} 
                                />
                              </div>
                              <form onSubmit={(event) => {
            event.persist();
            event.preventDefault();
            fetch(`http://localhost:3001/chess/${id}`, {
                method: "DELETE",
                
            })
            .then(() =>
            {
                navigate("/");
            })
            .catch(console.log);
            }}>
                              <div>
<NavLink to={"/"}><button className="bi bi-backspace">&nbsp;Mégsem</button></NavLink>
&nbsp;&nbsp;
<button className="bi bi-trash3">&nbsp;Törlés</button></div></form>   
                        </div>
                    
                )}
            </div>
        );
}
    export default SakkozoDelPage;