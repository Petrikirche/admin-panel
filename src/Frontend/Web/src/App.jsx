import { useEffect, useState } from "react";
import { ListGroup, Container, Col, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import "./App.css";
im
function App() {
    const [events, setEvents] = useState(null);
    const navigate = useNavigate();
    async function sendRequest(method, url, succesAction) {
        const requestOptions = {
            method: method,
        };
        fetch("https://localhost:7012/api/" + url, requestOptions)
            .then((res) => res.json())
            .then((data) => {
                succesAction(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
    }

    useEffect(() => {
        sendRequest("GET", "Event", function (data) {
            setEvents(data);
        });
    }, []);

    const logout = (e) => {
        e.preventDefault();
        sendRequest("POST", "Auth/logout", function (data) {
            navigate("/login");
        });
    };

    return (
        <Container>
            <ListGroup>
                {events?.map((event) => (

                    <ListGroup.Item key={event.id}>
                        <Row>
                            <Col sm={2}>
                                <img
                                    src="../"
                                    alt="Logo"
                                />
                            </Col>
                            <Col sm={9}>
                                <Row>
                                    <p>{event.eventName}</p>
                                    <p>{event.eventDate}</p>
                                </Row>
                            </Col>
                        </Row>
                    </ListGroup.Item>
                ))}
            </ListGroup>
        </Container>
    );
}

export default App;
