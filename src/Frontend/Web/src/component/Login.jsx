import { Form, Container, Row, Button } from "react-bootstrap";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
function Login() {
    const navigate = useNavigate();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const login = async (e) => {
        e.preventDefault();

        fetch("https://localhost:7012/api/Auth", {
            method: "POST",
            credentials: "include",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ username: username, password: password }),
        })
            .then(function (response) {
                if (response.status !== 200) {
                    console.log(
                        "Looks like there was a problem. Status Code: " +
                            response.status
                    );
                    return;
                }
                navigate("/");
            })
            .catch(function (err) {
                console.log("Fetch Error :-S", err);
            });
    };
    return (
        <Container>
            <Container style={{ minHeight: "70%" }}></Container>
            <Form>
                <Form.Group className="mb-3" controlId="formBasicUsername">
                    <Form.Label>Логин</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Логин"
                        onChange={(e) => {
                            setUsername(e.target.value);
                        }}
                        value={username}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Пароль</Form.Label>
                    <Form.Control
                        type="password"
                        placeholder="Пароль"
                        onChange={(e) => {
                            setPassword(e.target.value);
                        }}
                        value={password}
                    />
                </Form.Group>
                <Button variant="primary" type="submit" onClick={login}>
                    Submit
                </Button>
            </Form>
        </Container>
    );
}

export default Login;
