using System.Web;
using System.Web.Optimization;

namespace FamilyTreeMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            //bundles.Add(new ScriptBundle("~/bundles/sigma").Include(
            //"~/Scripts/graph/sigma/src/sigma.core.js",
            //   "~/Scripts/graph/sigma/src/conrad.js",
            //   "~/Scripts/graph/sigma/src/utils/sigma.utils.js",
            //   "~/Scripts/graph/sigma/src/utils/sigma.polyfills.js",
            //   "~/Scripts/graph/sigma/src/sigma.settings.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.dispatcher.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.configurable.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.graph.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.camera.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.quad.js",
            //   "~/Scripts/graph/sigma/src/classes/sigma.classes.edgequad.js",
            //   "~/Scripts/graph/sigma/src/captors/sigma.captors.mouse.js",
            //   "~/Scripts/graph/sigma/src/captors/sigma.captors.touch.js",
            //   "~/Scripts/graph/sigma/src/renderers/sigma.renderers.canvas.js",
            //   "~/Scripts/graph/sigma/src/renderers/sigma.renderers.webgl.js",
            //   "~/Scripts/graph/sigma/src/renderers/sigma.renderers.svg.js",
            //   "~/Scripts/graph/sigma/src/renderers/sigma.renderers.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/webgl/sigma.webgl.nodes.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/webgl/sigma.webgl.nodes.fast.js",
            //   "~/Scripts/graph/sigma/src/renderers/webgl/sigma.webgl.edges.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/webgl/sigma.webgl.edges.fast.js",
            //   "~/Scripts/graph/sigma/src/renderers/webgl/sigma.webgl.edges.arrow.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.labels.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.hovers.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.nodes.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edges.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edges.curve.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edges.arrow.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edges.curvedArrow.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edgehovers.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edgehovers.curve.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edgehovers.arrow.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.edgehovers.curvedArrow.js",
            //   "~/Scripts/graph/sigma/src/renderers/canvas/sigma.canvas.extremities.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.utils.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.nodes.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.edges.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.edges.curve.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.labels.def.js",
            //   "~/Scripts/graph/sigma/src/renderers/svg/sigma.svg.hovers.def.js",
            //   "~/Scripts/graph/sigma/src/middlewares/sigma.middlewares.rescale.js",
            //   "~/Scripts/graph/sigma/src/middlewares/sigma.middlewares.copy.js",
            //   "~/Scripts/graph/sigma/src/misc/sigma.misc.animation.js",
            //   "~/Scripts/graph/sigma/src/misc/sigma.misc.bindEvents.js",
            //   "~/Scripts/graph/sigma/src/misc/sigma.misc.bindDOMEvents.js",
            //   "~/Scripts/graph/sigma/src/misc/sigma.misc.drawHovers.js"
            //   ));
        }
    }
}
