import React, { Component, useEffect, useState } from 'react';

import './ModalWindow.css';


const ModalWindow = ({ showDetailsId, handleOnCreate, setShowDetailsId, setShowModal }) => {
    const [url, setUrl] = useState("");
    const [dataUrl, setDataUrl] = useState(null);

    useEffect(() => {
        if (showDetailsId) {
            fetch(`shorturls/geturls/${showDetailsId}`)
                .then(response => response.json())
                .then(response => setDataUrl(response));
        }
    }, [showDetailsId])

    const handleOnCloseWindow = () => {
        setShowDetailsId('');
        setShowModal(false);
    }

    return <div className='wrapper'>
        {showDetailsId ? dataUrl && <table className='styled-table'>
            <tbody>
                <tr>
                    <td className='bold'>Full URL</td>
                    <td>{dataUrl.fullUrl}</td>
                </tr>
                <tr>
                    <td className='bold'>Created By</td>
                    <td>{dataUrl.createdBy}</td>
                </tr>
                <tr>
                    <td className='bold'>Created Date</td>
                    <td>{dataUrl.createdDate}</td>
                </tr>
                <tr>
                    <td className='bold'>Short URL</td>
                    <td>{dataUrl.shortUrl}</td>
                </tr>
            </tbody>
        </table> :
            <div className='inputWrapper'><input type='text' placeholder="ENTER URL" value={url} onChange={(e) => setUrl(e.target.value)} />
                <button onClick={() => handleOnCreate(url)} className='btn btn-primary create'>CREATE</button></div>}
        <div className='closeBtn' onClick={handleOnCloseWindow}>X</div>
    </div>
}

export default ModalWindow;