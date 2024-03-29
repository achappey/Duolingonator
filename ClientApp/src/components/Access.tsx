import { ActionButton, TextField } from "@fluentui/react";
import { useCallback, useMemo, useState } from "react";
import { Buffer } from 'buffer';

export const Access: React.FunctionComponent = () => {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const updateUsername = useCallback((name: string | undefined) => {
        setUsername(name ? name : "")
    }, [])

    const updatePassword = useCallback((value: string | undefined) => {
        setPassword(value ? value : "")
    }, [])

    const decoded: string = useMemo(() => {
        return username && password ? Buffer.from(`${username}:${password}`).toString('base64') : "";
    }, [username, password])

    const copyToClipboard = useCallback(() => {
        navigator.clipboard.writeText(decoded).then(() => {
            console.log('Async: Copying to clipboard was successful!');
        }, (err) => {
            console.error('Async: Could not copy text: ', err);
        });
    }, [decoded]);

    return <>
        <div>
            <p>Calculate your API key</p>
            <form>
                <TextField required
                    value={username}
                    onChange={(_e, newValue) => updateUsername(newValue)}
                    label="Duolingo username" />
                <TextField required type="password"
                    value={password}
                    canRevealPassword
                    onChange={(_e, newValue) => updatePassword(newValue)}
                    label="Duolingo JWT token" />
            </form>
            <br />
            <TextField value={decoded}
                label="Duolingonator API Key"
                disabled={true} />
            <ActionButton onClick={copyToClipboard}>Copy to clipboard</ActionButton>
            <br />
            <br />
            <small>Calculation is browser-based. Your data is not stored anywhere.</small>
        </div>
    </>
}