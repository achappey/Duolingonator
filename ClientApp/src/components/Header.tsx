import { Breadcrumb, Stack, StackItem } from "@fluentui/react"
import { useMemo } from "react";
import { useLocation } from "react-router";

export const Header: React.FunctionComponent = () => {
    const { pathname } = useLocation();

    const items = useMemo(() => {
        const result = [{ key: "root", text: "Duolingonator" }];

        if (pathname.length > 1) {
            result.push({ key: pathname, text: pathname[1].toUpperCase() + pathname.substring(2) });
        }

        return result;
    }, [pathname]);

    return <Stack horizontal={true}>
        <StackItem grow={1}>
            <Breadcrumb items={items} />
        </StackItem>
        <StackItem align="end">
        </StackItem>
    </Stack>
}