document.addEventListener('DOMContentLoaded', () => {
    const scrollLinks = document.querySelectorAll('[data-scroll]');

    scrollLinks.forEach(link => {
        link.addEventListener('click', evt => {
            const targetId = link.getAttribute('href');
            if (targetId && targetId.startsWith('#')) {
                evt.preventDefault();
                const target = document.querySelector(targetId);
                if (target) {
                    target.scrollIntoView({ behavior: 'smooth', block: 'start' });
                }
            }
        });
    });
});
