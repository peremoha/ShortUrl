import React, { Component, useEffect, useState } from 'react';
import ModalWindow from './ModalWindow';
import { useAuth } from '../../context/AuthContext';
import './Home.css'

const Home = () => {
  const [urls, setUrls] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [showDetailsId, setShowDetailsId] = useState('');
  const { user } = useAuth();

  const userToken = user?.token;
  const isAdmin = user?.role === 'Admin';
  const login = user?.login;

  const getAllUrls = () => {
    fetch("shorturls/geturls")
      .then(response => response.json())
      .then(response => setUrls(response));
  }

  useEffect(() => {
    getAllUrls();
  }, [])

  const handleDetails = (id) => {
    setShowDetailsId(id); 
    setShowModal(true);
  }

  const handleOnDelete = async (e) => {
    await fetch(`shorturls/deleteurls/${e.target.id}`,
      {
        method: "DELETE",
        headers: { 'Content-Type': 'application/json' },
      });
    getAllUrls();
  }

  const handleOnCreate = async (url) => {
    await fetch(`shorturls/addurls`,
      {
        method: "POST",
        headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${userToken}` },
        body: JSON.stringify({
          FullUrl: url,
        })
      }).then((res) => {
        if (res.status === 409) {
          alert("This link already exist!")
        } else {
          getAllUrls();
          setShowModal(false)
        }
      })
  }

  return (
    <>
      <div className='headerWrap'>
        <h1>List of URLS</h1>
        {userToken && <button className='btn btn-primary' onClick={() => setShowModal(true)}>Add new Url</button>}
      </div>
      <table className='styled-table'>
        <thead>
          <tr>
            <th>Full URL</th>
            <th>Short URL</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {urls.map(item => (
            <tr key={item.id} >
              <td>{item.fullUrl}</td>
              <td onClick={() => handleDetails(item.id)} className='shortUrl'>{item.shortUrl}</td>
              <td>{userToken && (isAdmin || login === item.createdBy) &&<button id={item.id} className='btn btn-primary' onClick={handleOnDelete}>DELETE</button>}</td>
              <td><button className='btn btn-primary' onClick={() => handleDetails(item.id)}>View Details</button></td>
            </tr>
          ))}
        </tbody>
      </table>
      {showModal && <ModalWindow
        handleOnCreate={handleOnCreate}
        showDetailsId={showDetailsId}
        setShowDetailsId={setShowDetailsId}
        setShowModal={setShowModal} />}
    </>

  );
}

export default Home;

