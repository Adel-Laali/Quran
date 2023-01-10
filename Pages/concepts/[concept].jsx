const fs = require('fs');
const path = require('path');
import Error from 'next/error';
import { marked } from 'marked';
import { useRouter } from 'next/router'

const Concept = ({ urlSegments, content, errorCode, type }) => {

    const router = useRouter()
    // set title from <h1> or first line with # in markdowns
    // include disqus maybe

    if (errorCode) {
        return <Error statusCode={errorCode} />
    }

    return <>
        <div onClick={() => router.push('/')} className="p-5 cursor-pointer">Home</div>
        <div className={type + (type === 'markdown' ? ' prose pl-10 mb-10 pt-4' : '')} dangerouslySetInnerHTML={{ __html: content }}></div>
    </>
}

export async function getServerSideProps({ params, res }) {
    const urlSegments = params.concept || [];
    const diskSegments = [process.cwd(), 'contents', 'concepts'].concat(urlSegments);
    var filePath = path.join.apply(null, [...diskSegments, 'index.html']);
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments, 'index.md']);
    }
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments]) + '.md';
    }
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments]) + '.html';
    }
    console.log(filePath);
    if (!fs.existsSync(filePath)) {
        res.statusCode = 404;
        const result = { props: { urlSegments: urlSegments, errorCode: 404 } }
        return result;
    }
    else {
        var type = 'html';
        try {
            var content = fs.readFileSync(filePath, 'utf8');
            if (filePath.endsWith('.md')) {
                type = 'markdown';
                if (content.charCodeAt(0) == 65279) {
                    content = content.slice(1);
                }
                content = marked.parse(content);
            }
            const result = { props: { urlSegments: urlSegments, content: content, type } };
            return result;
        } catch (e) {
            console.log(e);
            res.statusCode = 500;
            const result = { props: { urlSegments: urlSegments, errorCode: 500 } }
            return result;
        }
    }
}

export default Concept;