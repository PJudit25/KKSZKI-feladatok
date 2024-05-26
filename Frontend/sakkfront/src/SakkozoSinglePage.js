import React, { useState, useEffect } from 'react';
import { useParams, NavLink } from 'react-router-dom';

export function SakkozoSinglePage(props) {
    const params = useParams();
    const id = params.sakkozoId;
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
                                <h5 className="card-title">{sakkozo.name}</h5>
                                <div className="lead">Születési idő: {sakkozo.birth_date}</div> 
                                <div className="lead">Megnyert bajnokságok: {sakkozo.world_ch_won }</div>
                                <div className="lead">Profil link: <a href={sakkozo.profile_url} target='_blank'>{sakkozo.profile_url}</a></div>
                                    <img alt={sakkozo.name}
                                    className="img-fluid rounded"
                                    style={{maxHeight: "500px"}}
                                    src={sakkozo.image_url ? sakkozo.image_url : 
                                    "https://via.placeholder.com/400x800"} 
                                    />
                                  </div>
                                  <div><NavLink to="/"><i class="bi bi-backspace"></i></NavLink> &nbsp;&nbsp;&nbsp;
<NavLink key="y" to={"/mod-sakkozo/" + sakkozo.id}><i class="bi bi-pencil"></i></NavLink></div>   
                            </div>
                        
                    )}
                </div>
            );
}
export default SakkozoSinglePage;