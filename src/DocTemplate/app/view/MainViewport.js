/*
 * File: app/view/MainViewport.js
 *
 * This file was generated by Sencha Architect version 2.2.1.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.2.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.2.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('JsonDoc.view.MainViewport', {
    extend: 'Ext.container.Viewport',

    requires: [
        'Ext.tab.Panel',
        'Ext.layout.container.Border',
        'Ext.grid.column.Boolean',
        'Ext.tree.Panel'
    ],

    layout: {
        type: 'border'
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'treepanel',
                    flex: 1,
                    region: 'west',
                    itemId: 'tpFiles',
                    width: 156,
                    title: 'JSON文件',
                    viewConfig: {

                    }
                },
                {
                    xtype: 'treepanel',
                    flex: 4,
                    region: 'center',
                    itemId: 'tgSchema',
                    title: 'JSON文件内容',
                    store: 'SchemaStore',
                    rootVisible: false,
                    useArrows: true,
                    viewConfig: {

                    },
                    columns: [
                        {
                            xtype: 'treecolumn',
                            dataIndex: 'name',
                            text: '属性名'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'type',
                            text: '类型'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'title',
                            text: '标题'
                        },
                        {
                            xtype: 'booleancolumn',
                            dataIndex: 'required',
                            text: '必须',
                            falseText: 'N',
                            trueText: 'Y'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'description',
                            text: '说明',
                            flex: 1
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});