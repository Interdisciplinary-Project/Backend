import logo from '../../../public/logo.svg';
import tailwindConfig from "../../../tailwind.config";

function Footer() {
    return (
        <footer className="w-full h-[234px] bg-light-social-brand absolute bottom-0">
            <figure 
                className="flex gap-12 items-center cursor-pointer px-[188px] pt-[70px]"
                title="Voltar à home"
                aria-label="Voltar à página inicial do Grupo Escoteiro Terra Da Saudade"
            >
                <img
                    className="w-[95px] h-[95px]"
                    src={logo}
                    alt="Árvore com um machado cravado no meio dela, diversos galhos e folhas."
                />
                <p
                    className="max-w-[580px] text-[16px]"
                >
                    Juntos construímos um mundo melhor. Cada gesto transforma sonhos em realidade.
                    Lado a lado, desafios viram oportunidades e a esperança se torna ação. 
                    Somos parte de algo maior, e juntos, fazemos a diferença.
                </p>
                <caption className="text-[24px] pl-[80px] text-left">
                    Grupo <strong className="text-social-brand">Escoteiro</strong> Terra Da Saudade - 05/SP
                </caption>
            </figure>
            <div className="w-full text-center pt-8">
                <small className="text-social-gray">© Todos direitos reservados</small>
            </div>
        </footer>
    );
}

export { Footer }