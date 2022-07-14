import { INavLinkGroup, Nav } from "@fluentui/react"
import { useMemo } from "react";
import { useLocation } from "react-router";

export const SideNavigation: React.FunctionComponent = () => {
    const { pathname } = useLocation();
    
    const navLinkGroups: INavLinkGroup[] = useMemo(() => [
        {
            links: [
                {
                    name: 'Home',
                    url: '/',
                    icon: 'Home',
                    key: '/'
                },
                {
                    name: 'API Key',
                    url: '/access',
                    icon: 'Settings',
                    key: '/access'
                },
                {
                    name: 'Swagger',
                    url: '/swagger',
                    key: '/swagger',
                    icon: 'Code',
                    target: '_blank',
                }
            ],
        },
    ], []);

    return <Nav
        selectedKey={pathname}
        groups={navLinkGroups}
    />
}