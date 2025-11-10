(function () {
    const links = document.querySelectorAll('a[href*="#"]');
    links.forEach(link => {
        link.addEventListener('click', function (event) {
            const rawHref = this.getAttribute('href');
            if (!rawHref || rawHref.startsWith('javascript') || rawHref.startsWith('http')) {
                return;
            }

            let hash = null;
            try {
                const url = new URL(rawHref, window.location.origin);
                hash = url.hash;
            } catch (error) {
                if (rawHref.includes('#')) {
                    hash = rawHref.substring(rawHref.indexOf('#'));
                }
            }

            if (!hash || hash.length <= 1) {
                return;
            }

            const targetElement = document.querySelector(hash);
            if (!targetElement) {
                return;
            }

            event.preventDefault();
            targetElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
        });
    });
})();
