
import axios from 'axios';

const searchImages = async (term) => {
    const response = await axios.get('https://api.unsplash.com/search/photos', {
        headers: {
            /*Authorization: 'Client-ID 8O50V7bNzfKdVixwS9W9nZVdr0VnrCv9gmeimfdvp6Y',*/
            Authorization: 'Client-ID iHrhWb1FrqHJhYX214QUBtc1SzCh9g98edidn4v1RuU',
        },
        params: {
            query: term,
        },
    });

    return response.data.results;
};


class Images {
    constructor() {
        this.$form = document.getElementById("searchForm");
        this.$searchBar = document.getElementById("searchBar");
        this.$submit = document.getElementById("searchSubmit");

        this.$searchResults = document.getElementById("searchResults")

        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.$form.addEventListener("submit", this.onFormSubmit);

        this.results;
    }

    addEventListeners() {
        //
    }

    onFormSubmit(event) {
        event.preventDefault();
        const searchTerm = this.$searchBar.value;

        this.results = searchImages(searchTerm);
    }

    displaySearchResults() {
        for (i in range(0, this.results.length())) {
            const currentResult = this.results[i];
            const currentUrl = currentResult.urls.regular;
            let theForm = this.createForm(currentUrl)
        }
    }

    createForm(imageUrl, onSubmit) {
        return (<form method="post">
            <img src={imageUrl}></img>
            <input hidden type="submit"></input>
        </form>)
    }
}

window.onload = () => { new Images }

/*

<h2>Search Pictures</h2>
<form method="post" id="searchForm">
    <label>Search Term</label>
    <input name="term" id="searchBar"/>
    <input type="submit" id="searchSubmit"/>
</form>
<div id="searchResults"></div>


*/