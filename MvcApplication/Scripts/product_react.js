var data = [   
                {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerChai.jpg", ProductName: "chai", Price: "94 nis", ID: "1"},
                {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerVelvet.jpg", ProductName: "velvet", Price: "104 nis", ID: "2"},
                {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerAnise.jpg", ProductName: "Anise", Price: "120 nis", ID: "3"}
];

var results = [];
results.push(data);
    
data = [       
               {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerPink.jpg", ProductName: "Pink", Price: "24 nis", ID: "4"},
               {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerRay.jpg", ProductName: "Ray", Price: "34 nis", ID: "5"},
               {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerRose.jpg", ProductName: "Rose", Price: "40 nis", ID: "6"}
];

results.push(data);

//מייצג מוצר אחד
//this.props.currentProduct - בכל פעם נכניס לזה מוצר אחר
    var Product = React.createClass({
        render: function() {                        
            return (
                <div className="product">
                    <div className="image">
                        <img src={this.props.currentProduct.Url} className="imagepro" alt="flower" />
                    </div>
                    <div className="nameProduct">
                        <div className="left">
                            <b>{this.props.currentProduct.ProductName}</b>
                        </div>
                        <div className="right">
                            <b>{this.props.currentProduct.Price}</b>
                        </div>
                    </div>
                    <div className="btnmoredetails">
                        <a href="#" className="btn btn-primary btnmoredetails" role="button">more details</a>
                    </div>
               </div>               
            );
        }
    });
//מייצג את כל המוצרים
    var ProductList = React.createClass({
        render: function() {
            return(
                    <div>
                    {this.props.results.map(function(result) {
                        return ( //מייצג שורה של מוצרים
                                 <div key={result[0].ID}>
                                       <div className="productLeft">
                                          <Product currentProduct={result[0]} />
                                       </div>
                                       <div className="productMiddle">
                                          <Product currentProduct={result[1]} />
                                       </div>
                                       <div className="productRight">
                                          <Product currentProduct={result[2]} />
                                       </div>
                                  </div>
                             );
                    })}
                    </div>
            );
        }
    });

            var ProductsBox = React.createClass({
                getInitialState: function() {
                    return {results: this.props.results};
                },

                handleClick: function() {
                    data = [       
                       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerPink.jpg", ProductName: "Pink", Price: "24 nis", ID: "6"},
                       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerRay.jpg", ProductName: "Ray", Price: "34 nis", ID: "7"},
                       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerRose.jpg", ProductName: "Rose", Price: "40 nis", ID: "8"}
                            ];

                    var newList = this.state.results.concat([data]);
                    this.setState({results : newList});
                },

                render: function() {
                    return (
                            <div>
                              <ProductList results={this.state.results} />
                              <div className="btnmoredetails">
                                <a href="#" onClick={this.handleClick} className="btn btn-primary btnmoredetails" role="button">More items</a>
                              </div> 
                            </div>
                   );
        }
    });

    ReactDOM.render(
        <ProductsBox results={results} />,
        document.getElementById('products')
    ); 